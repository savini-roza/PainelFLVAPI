using PainelFLVAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("Produto", Schema = "dbo")]
    public class Produto
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Categoria")]
        public char Categoria { get; set; }
    }
}
