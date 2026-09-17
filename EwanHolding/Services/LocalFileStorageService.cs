using EwanHolding.Application.Exceptions;

namespace EwanHolding.Api.Services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _env;

        // Keep this tight: only what the site actually needs (logos, news/company/investment images, icons).
        // Executable/script extensions are deliberately NOT allowed, to avoid someone uploading a .html/.js/.exe
        // disguised with an image content-type and having it served back from wwwroot.
        private static readonly Dictionary<string, string[]> AllowedContentTypesByExtension = new()
        {
            [".jpg"] = new[] { "image/jpeg" },
            [".jpeg"] = new[] { "image/jpeg" },
            [".png"] = new[] { "image/png" },
            [".webp"] = new[] { "image/webp" },
            [".gif"] = new[] { "image/gif" },
            [".svg"] = new[] { "image/svg+xml" },
            [".pdf"] = new[] { "application/pdf" },
        };

        private const long MaxFileSizeBytes = 5 * 1024 * 1024; // 5 MB

        public LocalFileStorageService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string subFolder)
        {
            if (file == null || file.Length == 0)
                throw new BadRequestException("No file was uploaded.");

            if (file.Length > MaxFileSizeBytes)
                throw new BadRequestException($"File is too large. Maximum allowed size is {MaxFileSizeBytes / (1024 * 1024)} MB.");

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!AllowedContentTypesByExtension.TryGetValue(extension, out var allowedContentTypes))
                throw new BadRequestException($"File type '{extension}' is not allowed. Allowed types: {string.Join(", ", AllowedContentTypesByExtension.Keys)}");

            // Belt-and-braces: also check the declared content-type against the extension, since the
            // extension alone can be spoofed just as easily as the content-type header.
            if (!allowedContentTypes.Contains(file.ContentType, StringComparer.OrdinalIgnoreCase))
                throw new BadRequestException("The file's content type does not match its extension.");

            var safeSubFolder = string.IsNullOrWhiteSpace(subFolder)
                ? "misc"
                : new string(subFolder.Where(c => char.IsLetterOrDigit(c) || c is '-' or '_').ToArray());

            var webRoot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
            var uploadsFolder = Path.Combine(webRoot, "uploads", safeSubFolder);
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid():N}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{safeSubFolder}/{fileName}";
        }

        public void DeleteFile(string relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(relativeUrl) || !relativeUrl.StartsWith("/uploads/"))
                return; // don't try to delete external URLs or anything outside our own uploads folder

            var webRoot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
            var fullPath = Path.Combine(webRoot, relativeUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
