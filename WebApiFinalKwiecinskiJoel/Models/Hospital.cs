using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalKwiecinskiJoel.Models
{

    [Table("Hospital")]
    public class Hospital
    {

        [Key]
        [Required]
        public int HospitalCod { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Direccion { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Telefono { get; set; }

        public int? Num_Cama { get; set; }


        #region Navegación

        public List<Doctor> Doctors { get; set; }

        #endregion
    }
}
