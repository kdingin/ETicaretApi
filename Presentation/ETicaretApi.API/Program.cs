using ETicaretApi.Application;
using ETicaretApi.Application.Validators.Products;
using ETicaretApi.Infrastructure;
using ETicaretApi.Infrastructure.Filters;
using ETicaretApi.Infrastructure.Services.Storage.Azure;
using ETicaretApi.Infrastructure.Services.Storage.Local;
using ETicaretApi.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddAplicationServices();   
//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();
builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
));

// Add services to the container.
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
  .AddFluentValidation(configuration=>configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
  .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseCors();  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
