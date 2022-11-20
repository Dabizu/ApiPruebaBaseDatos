// See https://aka.ms/new-console-template for more information


using ConsoleEF.Models;
using System;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new pruebaContext())
            {
                var user = new User();
                user.User1 = "fernando";
                user.Password= "2222";
                context.Users.Add(user);
                context.SaveChanges();


                /*
                foreach(var user in context.Users.ToList())
                {
                    Console.WriteLine(user.Password);
                }*/
            }
        }
    }
}