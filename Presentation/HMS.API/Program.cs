using FluentValidation.AspNetCore;
using HMS.Application.Mapping;
using HMS.Application.Validators;
using HMS.Persistence;
using Serilog;
using Serilog.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) 
    => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddPersistenceServices();
builder.Services.AddControllers()
    .AddFluentValidation(configuration => 
    configuration.RegisterValidatorsFromAssemblyContaining<CreateAppointmentValidator>());


builder.Services.AddAutoMapper(typeof(CustomProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
