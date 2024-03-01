//this is middleware file

using System.Text;
using EventBusiness.Services;
using EventData.DataContext;
using EventData.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using NLog.Web;

//passing configuration file here the file is nlog.Config
var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

//builder-container
var builder = WebApplication.CreateBuilder(args);//API

//Api security
//Jwt configuration starts here
var jwtIssuer = builder.Configuration.GetSection("Jwt:Issuer").Get<string>();
var jwtKey = builder.Configuration.GetSection("Jwt:Key").Get<string>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = jwtIssuer,
    ValidAudience = jwtIssuer,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
  };
});
//Jwt configuration ends here

try
{

    // Add services to the container.
    //container -services
    builder.Services.AddControllers();

    //versionning
    builder.Services.AddApiVersioning(x =>
    {
        x.DefaultApiVersion = new ApiVersion(1, 0);
        x.AssumeDefaultVersionWhenUnspecified = true;
        x.ReportApiVersions = true;
    });
    //-----------------------------------------------------------------------------------------------------------------
    //read coonection string from appsetting.json file
    string conStr = builder.Configuration.GetConnectionString("sqlcon");
    //add connection string
    builder.Services.AddDbContext<EventDbContext>(obj => obj.UseSqlServer(conStr)); //API-business-data

    builder.Services.AddScoped<EventService, EventService>();//object will be created -- to access the instances we have create the construcor in every class
    builder.Services.AddScoped<IEventRepository, EventRepository>();//creating object assigning to interface

    builder.Services.AddScoped<IUserRepo, UserRepo>();
    builder.Services.AddScoped<UserService, UserService>();

    builder.Services.AddScoped<IEventBooking, EventBookigRepo>();
    builder.Services.AddScoped<BookingService, BookingService>();

    //------------------------------------------------------------------------------------------------------------------
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors();

    //process of nlog  loggin page
    builder.Services.AddLogging(log =>
    {
        log.ClearProviders();
        log.AddNLog();
    });


    var app = builder.Build();//instance will be created.getting instance.


    //actual middle ware will work from here
    // Configure the HTTP request pipeline.
    //Dev,Testing,Production,QA
    if (app.Environment.IsDevelopment())//
    {
        app.UseSwagger();//middleware
        app.UseSwaggerUI();//middleware
    }
    app.UseCors(x => x.AllowAnyMethod()
                     .AllowAnyHeader()
                     .SetIsOriginAllowed(origin => true)
                     .AllowCredentials());

    //app.UseAuthentication();//login person can access,registerd person
    app.UseAuthorization();//middleware

    app.MapControllers();//middleware -this for accessing controllers

    app.Run();//middleware->connect to the controller
}
catch(Exception ex) 
{
    logger.Error(ex, "Stopped program");
}
finally
{
    NLog.LogManager.Shutdown();
}
// 1.Container -- builder
//2.Middleware- App