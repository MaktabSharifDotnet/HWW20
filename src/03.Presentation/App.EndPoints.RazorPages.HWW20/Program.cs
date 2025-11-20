
using App.Domain.AppServices.AppointmentRequestAgg;
using App.Domain.AppServices.CarModelAgg;
using App.Domain.Core.AppointmentRequestAgg.Contracts.AppService;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Repo;
using App.Domain.Core.AppointmentRequestAgg.Contracts.Service;
using App.Domain.Core.CarModelAgg.Contracts.AppService;
using App.Domain.Core.CarModelAgg.Contracts.Repository;
using App.Domain.Core.CarModelAgg.Contracts.Service;
using App.Domain.Services.AppointmentRequestAgg;
using App.Domain.Services.CarModelAgg;
using App.Infra.Data.Repos.Ef.AppointmentRequestAgg;
using App.Infra.Data.Repos.Ef.CarModelAgg;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
              options.UseSqlServer("Server=DESKTOP-M2BLLND\\SQLEXPRESS;Database=HWW20;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<IAppointmentRequestRepo , AppointmentRequestRepo>();
builder.Services.AddScoped<IAppointmentRequestService, AppointmentRequestService>();
builder.Services.AddScoped<IAppointmentRequestAppService, AppointmentRequestAppService>();
builder.Services.AddScoped<ICarModelRepo, CarModelRepo>();
builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();

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
