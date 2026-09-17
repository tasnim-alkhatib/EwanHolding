using EwanHolding.Api.Filters;
using EwanHolding.Api.Middlewares;
using EwanHolding.Api.Services;
using EwanHolding.Application.Repositories.Implementation;
using EwanHolding.Application.Repositories.Interfaces;
using EwanHolding.Application.Services.Implementation;
using EwanHolding.Application.Services.Interfaces;
using EwanHolding.Application.UnitOfWork;
using EwanHolding.Application.Validators;
using EwanHolding.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Convert enum to string in json response
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// CORS: allow the frontend origin(s) configured in appsettings (per environment)
var corsPolicyName = "EwanHoldingFrontend";
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // remove this line if the frontend never sends cookies/credentials
    });
});

builder.Services.AddDbContext<EwanHoldingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["AppSettings:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["AppSettings:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:token"]!)),
            ValidateIssuerSigningKey = true

        };
    });

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<ICoreValueService, CoreValueService>();
builder.Services.AddScoped<IStatService, StatService>();
builder.Services.AddScoped<IInvestmentOpportunitiesService, InvestmentOpportunitiesService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<ITermsAndConditionsService, TermsAndConditionsService>();
builder.Services.AddScoped<IPageContentService, PageContentService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ICoreValueRepository, CoreValueRepository>();
builder.Services.AddScoped<IStatRepository, StatRepository>();
builder.Services.AddScoped<IInvestmentOpportunitiesRepository, InvestmentOpportunitiesRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<ITermsAndConditionsRepository, TermsAndConditionsRepository>();
builder.Services.AddScoped<IPageContentRepository, PageContentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFileStorageService, LocalFileStorageService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateAdminValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAdminValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<ChangePasswordValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCompanyValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCompanyValidator>();

var app = builder.Build();

// Must be first: wraps every other middleware so ANY unhandled exception below
// gets turned into a consistent JSON error response instead of a raw 500 page.
app.UseGlobalExceptionHandling();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Serves the uploaded files back out from wwwroot/uploads (needed for the Media upload endpoint above).
app.UseStaticFiles();

// Must be registered after routing/https-redirection and BEFORE Authentication/Authorization,
// otherwise the CORS preflight (OPTIONS) response headers won't be applied correctly.
app.UseCors(corsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
