namespace EwanHolding.Api.Services
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Saves an uploaded file to disk and returns the public relative URL (e.g. "/uploads/company/xxxx.jpg")
        /// that can be stored directly in Media.Url / Company.LogoUrl / CoreValue.IconUrl.
        /// Throws BadRequestException if the file is missing, too large, or not an allowed type.
        /// </summary>
        Task<string> SaveFileAsync(IFormFile file, string subFolder);

        /// <summary>Deletes a previously-uploaded file given the relative URL returned by SaveFileAsync. Safe to call even if the file no longer exists.</summary>
        void DeleteFile(string relativeUrl);
    }
}
