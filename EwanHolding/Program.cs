using EwanHolding.Api.Filters;
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
//builder.Services.AddScoped<IMediaService, MediaService>();
//builder.Services.AddScoped<ITermsAndConditionsService, TermsAndConditionsService>();
//builder.Services.AddScoped<IPageContentService, PageContentService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<ICoreValueRepository, CoreValueRepository>();
builder.Services.AddScoped<IStatRepository, StatRepository>();
builder.Services.AddScoped<IInvestmentOpportunitiesRepository, InvestmentOpportunitiesRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
//builder.Services.AddScoped<IMediaRepository, MediaRepository>();
//builder.Services.AddScoped<ITermsAndConditionsRepository, TermsAndConditionsRepository>();
//builder.Services.AddScoped<IPageContentRepository, PageContentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
