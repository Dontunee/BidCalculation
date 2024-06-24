using BidCalculation.Api;
using BidCalculation.Api.Models;
using BidCalculation.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddTransient<ICommonBasicFeeCalculator, CommonBasicFeeCalculator>();
builder.Services.AddTransient<ILuxuryBasicFeeCalculator, LuxuryBasicFeeCalculator>();
builder.Services.AddTransient<ICommonSpecialFeeCalculator, CommonSpecialFeeCalculator>();
builder.Services.AddTransient<ILuxurySpecialFeeCalculator, LuxurySpecialFeeCalculator>();
builder.Services.AddTransient<IAssociationFeeCalculator, AssociationFeeCalculator>();
builder.Services.AddTransient<FeeCalculatorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Enable CORS
app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();