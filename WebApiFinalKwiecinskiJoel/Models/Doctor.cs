using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalKwiecinskiJoel.Models
{

    [Table("Doctor")]
    public class Doctor
    {

        [Key]
        [Required]
        public int No { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Apellido { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Especialidad { get; set; }

        [Required]
        public int HospitalCod { get; set; }

        #region Navegación

        [ForeignKey("HospitalCod")]
        public Hospital Hospital { get; set; }

        #endregion
    }
}
