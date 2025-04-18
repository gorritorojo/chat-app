using System.Reflection.Metadata.Ecma335;
using data;
using data.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChatDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ChatDbContext")));
builder.Services.AddScoped<UserService>();

var app = builder.Build();


app.MapPost("api/users/register", async (UserService userService, [FromBody] RegisterRequest request) =>
{
    User? user;
    try
    {
        user = await userService.Register(request.Username, request.Password);
    }
    catch (Exception)
    {
        return Results.BadRequest("error al crear al usuario");
    }

    return Results.Ok(user);
});




app.MapGet("api/users/login", async (UserService userService, string username, string password) =>
{
    User? user;
    try
    {
        user = await userService.Login(username, password);
    }
    catch (Exception)
    {
        return Results.BadRequest("error al obtener al usuario");
    }
    if (user == null)
    {
        return Results.BadRequest("usuario no encontrado");
    }

    return Results.Ok(user);
});





app.Run();
