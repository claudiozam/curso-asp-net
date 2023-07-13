using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationSistemaDeReclamos.Models.ViewModels
{
    public class ReclamoViewModel
    {
        private long id;
        private string titulo;
        private string descripcion;
        private string estado;
        private DateTime fechaAlta;

        [DisplayName("Id auto generado")]
        public long Id { get => id; set => id = value; }

        [DisplayName("Titulo del producto")]
        [Required]
        public string Titulo { get => titulo; set => titulo = value; }

        [DisplayName("Descripcion")]
        [Required]
        [StringLength(100)]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Estado { get => estado; set => estado = value; }

        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
    }
}
