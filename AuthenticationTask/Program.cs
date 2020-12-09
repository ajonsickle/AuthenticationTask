using System;

namespace AuthenticationTask
{
    class Program
    {
        
            static void Main(string[] args)
            {

                string username = "";
                string password = "";

                addUser("tjc","hello","admin");
                Console.WriteLine("Authentication Sytem!");
                Console.WriteLine("Please type in your username");
                username = Console.ReadLine();
                Console.WriteLine("Please type in your password");
                password = Console.ReadLine();
                if (authenticateUser(username, password))
                {
                    Console.WriteLine("You have been authenticated!!!");
                }
                else
                {
                    Console.WriteLine("Invalid User");

                }


            }// Task 1
             /** Complete the authenticateUser function below, it should
              * 1) Create a stream reader, you can just use Users.csv as the path 
              * 2) Read one line at a time
              * 3) Split each line into username, password and access rights
              * 4) Compare to u and p to the username and password you have read from the file, if both match valid is set to true
              * Help:: Below are tutorials on filehandling and the split function
              * http://www.java2s.com/Tutorials/CSharp/System.IO/StreamReader/C_StreamReader_Peek.htm
              * https://www.tutlane.com/tutorial/csharp/csharp-string-split-method
              */
            static bool authenticateUser(string u, string p)
            {
            StreamReader sr = new StreamReader("Users.csv");
            while (sr.Peek() != -1)
            {
                var x = sr.ReadLine();
                var b = x.Split(',');
                if (b[0] == u && b[1] == p)
                {
                    sr.Close();
                    return true;
                }
                
            }
            sr.Close();
            return false;
            }
            //Task 2
            /** Complete the addUser subroutine, it should
            1) Open a fileWriter in append mode
            2) add the new users username, password and admin status(Admin or User) to the end of the file
            3) Test the Subroutine by removing the comment around the call to this function in main and loging in with username:tjc and password:hello
            */

            static void addUser(string u, string p, string a)
            {
            StreamWriter sw = new StreamWriter("Users.csv", true);
            sw.WriteLine($"{u}, {p}, {a}");
            sw.Close();
            }
    }
}
