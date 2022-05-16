using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Diagnostics.Tracing;

namespace OWASP.WebGoat.NET.App_Code
{
    public class AeeClass
    {
        private readonly string ConnectionString = "Server=SomeServer.local,1433;Initial Catalog=SomeDatabase;User ID=sa;Password=Abc123;";
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string SOME_PROPERTY { get; set; }
        public string someotherproperty { get; set; }

        public void MethodWithoutDispose(string something)
        {
            log.Info("Connection string: " + ConnectionString);
            Console.WriteLine("ConnectionString: " + ConnectionString);
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT " + something, sqlConnection);
            cmd.ExecuteReader();
        }

        public void MethodWithMagicStrings(string something)
        {
            if (something == "someconstant")
            {
                Console.WriteLine("someconstant");
            }
            else if (something == "someotherconstant")
            {
                Console.WriteLine("someotherconstant");
            }
            else if (something.Equals("abc123"))
            {
                Console.WriteLine("abc123");
            }
            Console.WriteLine("done");
        }

        public bool AuthenticateUser(string username, string password)
        {
            log.Info("Authenticating user with " + username + "/" + password);
            Console.WriteLine("Authenticated user with {0}/{1}", username, password);
            return password.Equals("abc123");
        }

        private string[] stringArray = new string[10];
        public string UncheckedIndexRange(int indexToGet)
        {
            return stringArray[indexToGet];
        }

        public string InfiniteLoop()
        {
            string returnValue = "done";

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                i = -1;
            }

            return returnValue;
        }
    }
}