using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<User> users = new List<User>
    {
        new User("admin", "admin"),
        new User("feherstefan", "jamasa123")
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Login();
                    break;
                case "2":
                    Register();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void Login()
    {
        Console.WriteLine("Enter your username:");
        var username = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        var password = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (user != null)
        {
            Console.WriteLine("You have successfully logged in!");
        }
        else
        {
            Console.WriteLine("Your username or password is incorrect. Please try again.");
        }
        Console.ReadLine();
    }

    static void Register()
    {
        Console.WriteLine("Enter your username:");
        var username = Console.ReadLine();

        var user = users.FirstOrDefault(u => u.Username == username);
        if (user != null)
        {
            Console.WriteLine("This account already exists.");
        }
        else
        {
            Console.WriteLine("Enter your password:");
            var password = Console.ReadLine();
            users.Add(new User(username, password));
            Console.WriteLine("Account created successfully.");
        }
        Console.ReadLine();
    }
}

public class User
{
    public string Username { get; }
    public string Password { get; }

    public User(string username, string password)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }
}
