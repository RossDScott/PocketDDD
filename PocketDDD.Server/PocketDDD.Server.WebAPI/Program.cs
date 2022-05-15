using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using PocketDDD.Server.DB;
using PocketDDD.Server.Services;
using PocketDDD.Server.WebAPI.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthorization(config =>
//{
//    config.AddPolicy("UserIsRegisterdPolicy", new AuthorizationPolicyBuilder()
//                        .AddRequirements(new UserIsRegisteredRequirement())
//                        .Build());
//});

builder.Services.AddDbContext<PocketDDDContext>(
    options => options.UseSqlServer("name=ConnectionStrings:PocketDDDContext"));

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<RegistrationService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<EventDataService>();
builder.Services.AddScoped<PrizeDrawService>();
builder.Services.AddScoped<SpeakersService>();

builder.Services.AddAuthentication()
                .AddScheme<UserIsRegisteredOptions, UserIsRegisteredAuthHandler>(UserIsRegisteredAuthHandler.SchemeName, null);


//builder.Services.AddScoped<IAuthorizationHandler, UserIsRegisteredRequirementHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
