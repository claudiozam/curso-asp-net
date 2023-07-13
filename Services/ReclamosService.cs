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

        public void BorrarReclamo(long id)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM reclamos WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Reclamo RecuperarReclamo(long id)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;
            if (dr.Read())
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt64("id");
                reclamo.Titulo = dr.GetString("titulo");
                reclamo.Descripcion = dr.GetString("descripcion");
                reclamo.Estado = dr.GetString("estado");
                reclamo.FechaAlta = dr.GetDateTime("fechaAlta");
            }

            connection.Close();

            return reclamo;
        }

        public List<Reclamo> RecuperarListadoDeReclamos()
        {
            List<Reclamo> reclamos = new List<Reclamo>();
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, titulo, descripcion, estado, fechaAlta FROM reclamos";
            MySqlDataReader dr = command.ExecuteReader();
            Reclamo reclamo = null;
            while (dr.Read())
            {
                reclamo = new Reclamo();
                reclamo.Id = dr.GetInt64("id");
                reclamo.Titulo = dr.GetString("titulo");
                reclamo.Descripcion = dr.GetString("descripcion");
                reclamo.Estado = dr.GetString("estado");
                reclamo.FechaAlta = dr.GetDateTime("fechaAlta");
                reclamos.Add(reclamo);
            }

            connection.Close();

            return reclamos;
        }

        public void ActualizarReclamo(Reclamo reclamo)
        {
            MySqlConnection connection = DbUtils.RecuperarConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE reclamos SET titulo = @titulo, descripcion = @descripcion, estado = @estado WHERE id = @id";
            command.Parameters.AddWithValue("@titulo", reclamo.Titulo);
            command.Parameters.AddWithValue("@descripcion", reclamo.Descripcion);
            command.Parameters.AddWithValue("@estado", reclamo.Estado);
            command.Parameters.AddWithValue("@id", reclamo.Id);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
