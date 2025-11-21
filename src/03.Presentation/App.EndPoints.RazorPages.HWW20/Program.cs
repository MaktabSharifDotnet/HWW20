
using App.Domain.AppServices.AppointmentRequest;
using App.Domain.AppServices.CarModelAgg;
using App.Domain.AppServices.OperatorAgg;
using App.Domain.Core.AppFileAgg;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Repository;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.CarModelAgg.Contratcs.AppService;
using App.Domain.Core.CarModelAgg.Contratcs.Repository;
using App.Domain.Core.CarModelAgg.Contratcs.Service;
using App.Domain.Core.OperatorAgg.Contracts.AppService;
using App.Domain.Core.OperatorAgg.Contracts.Repository;
using App.Domain.Core.OperatorAgg.Contracts.Service;
using App.Domain.Services.AppointmentRequestAgg;
using App.Domain.Services.CarModelAgg;
using App.Domain.Services.OperatorAgg;
using App.Infra.Data.Repos.Ef.AppFileAgg;
using App.Infra.Data.Repos.Ef.AppointmentRequestAgg;
using App.Infra.Data.Repos.Ef.CarModelAgg;
using App.Infra.Data.Repos.Ef.OperatorAgg;

using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>        
options.UseSqlServer("Server=DESKTOP-M2BLLND\\SQLEXPRESS;Database=HWW20;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<IAppointmentRequestRepository, AppointmentRequestRepository>();
builder.Services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
builder.Services.AddScoped<IAppointmentRequestAppService, AppointmentRequestAppService>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<ICarModelSerivce, CarModelSerivce>();
builder.Services.AddScoped<ICarModelAppSerivce, CarModelAppSerivce>();
builder.Services.AddScoped<IOperatorRepository , OperatorRepository>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IOperatorAppService, OperatorAppService>();
builder.Services.AddScoped<IFileUploader, FileUploader>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
