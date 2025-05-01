using SurvayBasket.Infrastructure;
using Microsoft.Extensions.Configuration; // Needed for builder.Configuration
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();   //  Handle exceptions

app.UseCors();     //  Allow all CORS requests
app.UseRouting();            //  Ensure routing happens before auth
app.UseAuthentication();     //  Authentication middleware
app.UseAuthorization();      //  Authorization middleware
app.MapControllers();        //  Map the controller endpoints


app.Run();
