using PainelFLVAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{
    [Table("Embalagem", Schema = "dbo")]
    public class Embalagem
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdFornecedor")]
        public int IdFornecedor { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Capacidade")]
        public string Capacidade { get; set; }

        [Column("Unidade")]
        public string Unidade { get; set; }

        [Column("Dimensoes")]
        public string Dimensoes { get; set; }

        [Column("IdMaterial")]
        public int IdMaterial { get; set; }

    }
}
