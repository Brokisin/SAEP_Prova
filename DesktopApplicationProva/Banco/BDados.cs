using System;
using MySqlConnector;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApplicationProva.Banco
{
    public class BDados
    {
        public static MySqlConnection connection;
        Banco banco = new Banco();

        public static void DBConnect()
        {
            Initialize();
        }

        public static void Initialize()
        {
            Banco banco = new Banco();

            banco.HostMySql = "10.200.116.71";
            banco.DataBaseMySql = "AmbienteEscolarAVA";
            banco.UsernameMySql = "admin";
            banco.PasswordMySql = "senai";

            string dataResponse;
            dataResponse = "SERVER=" + banco.HostMySql + ";" + "DATABASE=" +
            banco.DataBaseMySql + ";" + "UID=" + banco.UsernameMySql + ";" + "PASSWORD=" + banco.PasswordMySql + ";";

            try
            {
                connection = new MySqlConnection();
                connection.ConnectionString = dataResponse;
                //connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }

        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }

        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
