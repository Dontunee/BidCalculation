using BidCalculation.Models;
using BidCalculation.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICommonBasicFeeCalculator, CommonBasicFeeCalculator>();
builder.Services.AddTransient<ILuxuryBasicFeeCalculator, LuxuryBasicFeeCalculator>();
builder.Services.AddTransient<ICommonSpecialFeeCalculator, CommonSpecialFeeCalculator>();
builder.Services.AddTransient<ILuxurySpecialFeeCalculator, LuxurySpecialFeeCalculator>();
builder.Services.AddTransient<IAssociationFeeCalculator, AssociationFeeCalculator>();
builder.Services.AddTransient<FeeCalculatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Bid}/{action=Index}/{id?}");

app.Run();