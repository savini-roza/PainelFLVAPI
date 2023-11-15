using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("Fornecedor", Schema = "dbo")]
    public class Fornecedor : Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdUsuario")]
        public int IdUsuario { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("MediaAvaliacao")]
        public double MediaAvaliacao { get; set; }

        [Column("CNPJ")]
        public string CNPJ { get; set; }
    }
}
