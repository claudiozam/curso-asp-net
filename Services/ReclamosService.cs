using MySql.Data.MySqlClient;
using WebApplicationSistemaDeReclamos.Models;

namespace WebApplicationSistemaDeReclamos.Services
{
    public class ReclamosService
    {
        public void AltaDeReclamo(Reclamo reclamo)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO reclamos (titulo, descripcion, estado, fechaAlta) VALUES " 
                + " (@titulo, @descripcion, @estado, @fechaAlta);";
            command.Parameters.AddWithValue("@titulo", reclamo.Titulo);
            command.Parameters.AddWithValue("@descripcion", reclamo.Descripcion);
            command.Parameters.AddWithValue("@estado", reclamo.Estado);
            command.Parameters.AddWithValue("@fechaAlta", reclamo.FechaAlta);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public List<Reclamo> RecuperarListadoDeReclamos()
        {
            //TODO: FALTA EL BUSCAR EN LA BASE DE DATOS....
            return new List<Reclamo>();
        }
    }
}
