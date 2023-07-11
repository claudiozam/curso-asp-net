namespace WebApplicationSistemaDeReclamos.Models.ViewModels
{
    public class ReclamoViewModel
    {
        private long id;
        private string titulo;
        private string descripcion;
        private string estado;
        private DateTime fechaAlta;

        public long Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    }
}
