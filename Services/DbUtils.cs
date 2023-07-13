
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplicationSistemaDeReclamos.Services
{
    public class DbUtils
    {

        public static MySqlConnection RecuperarConnection()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            
            string connectionString = config.GetConnectionString("DefaultConnection");
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            return con;
        }
    }
}
