using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("Comprador", Schema = "dbo")]

    public class Comprador : Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("CNPJ")]
        public string CNPJ { get; set; }
    }
}
