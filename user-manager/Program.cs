using System;
using System.Collections.Generic;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Tel { get; set; }
}

public class HelloWorld
{
    public static List<User> listUser = new List<User>();

    public static void Main()
    {
        Console.WriteLine("Welcome To The User Manager");

        Console.WriteLine("Options:");
        Console.WriteLine("1. View Users");
        Console.WriteLine("2. Create User");
        Console.WriteLine("3. Delete User");
        Console.WriteLine("4. Update User");
        Console.WriteLine("5. Exit Program");

        Console.Write("Chose an Option: ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                ListUsers();
                break;
            case 2:
                CreateUser();
                break;
            case 3:
                DeleteUser();
                break;
            case 4:
                UpdateUser();
                break;
            case 5:
                return;
                break;
            default:
                Console.WriteLine("Option Invalid!");
                break;
        }
    }

    public static void CreateUser()
    {
        User newUser = new User();

        Console.Write("Enter the user name: ");
        newUser.Name = Console.ReadLine();

        Console.Write("Enter the user e-mail: ");
        newUser.Email = Console.ReadLine();

        Console.Write("Enter the user telephone: ");
        newUser.Tel = Convert.ToInt32(Console.ReadLine());

        listUser.Add(newUser);
        Console.WriteLine("User Created");
        Console.WriteLine("-----------------------------------");

        Main();
    }

    public static void ListUsers()
    {
        Console.WriteLine("Users List:");

        if (listUser.Count == 0)
        {
            Console.WriteLine("Users Not Found");
        }

        for (int i = 0; i < listUser.Count; i++)
        {
            User user = listUser[i];
            Console.WriteLine($"User: {i + 1}, Name: {user.Name}, Email: {user.Email}, Telephone: {user.Tel}");
        }

        Console.WriteLine("-----------------------------------");
        Main();
    }

    public static void DeleteUser()
    {
        if (listUser.Count <= 0)
        {
            Console.WriteLine("Not Exists Already Users");
            Console.WriteLine("-----------------------------------");
            Main();
        }

        Console.Write("Enter Name User: ");
        string userName = Console.ReadLine();

        User userExistInList = listUser.Find(user => user.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

        if (userExistInList != null)
        {
            listUser.Remove(userExistInList);
            Console.WriteLine("User Deleted");
            Console.WriteLine("-----------------------------------");
            Main();
        }
        else
        {
            Console.WriteLine("User Not Found");
            Console.WriteLine("-----------------------------------");
            Main();
        }
    }

    public static void UpdateUser()
    {
        if (listUser.Count <= 0)
        {
            Console.WriteLine("Not Exists Already Users");
            Console.WriteLine("-----------------------------------");
            Main();
        }

        Console.Write("Enter Name User: ");
        string userName = Console.ReadLine();

        int userExistInList = listUser.FindIndex(user => user.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

        if (userExistInList != -1)
        {
            Console.Write("New User Name: ");
            string newName = Console.ReadLine();

            Console.Write("New User Email: ");
            string newEmail = Console.ReadLine();

            Console.Write("New User Tel: ");
            int newTel = Convert.ToInt32(Console.ReadLine());

            listUser[userExistInList].Name = newName;
            listUser[userExistInList].Email = newEmail;
            listUser[userExistInList].Tel = newTel;

            Console.WriteLine("User Updated");
            Console.WriteLine("-----------------------------------");
            Main();
        }
        else
        {
            Console.WriteLine("User Not Found");
            Console.WriteLine("-----------------------------------");
            Main();
        }
    }
}