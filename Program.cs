using RenderSample.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var services = builder.Services;
var env = builder.Environment;

// Add services to the container.
builder.Services.AddHttpClient();

//For Entity Framework

builder.Services.AddDbContextAndConfigurations(env, config);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


builder.Services.AddAuthentication();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen();

builder.Services.AddCors();
;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); // other middleware }

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
