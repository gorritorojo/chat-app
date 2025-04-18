using BCrypt.Net;
using data;
using data.models;
using Microsoft.EntityFrameworkCore;

namespace service;


public class UserService
{
    private readonly ChatDbContext _context;

    public UserService(ChatDbContext context)
    {
        _context = context;
    }

    public async Task<User> Register(string username, string password)
    {
        string? HashPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var newUser = new User()
        {
            Username = username,
            Password = HashPassword
        };

        try
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
        catch (Exception ex)
        {
            throw new Exception($"error creating user", ex);
        }
    }

    public async Task<User?> Login(string username, string password)
    {
        User? user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            return null;
        }
        var correctPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
        if (!correctPassword)
        {
            return null;
        }

        return user;
    }

}
