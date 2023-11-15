using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("ContatoProdutorFornecedor", Schema = "dbo")]
    public class ContatoProdutorFornecedor
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdProdutor")]
        public int IdProdutor { get; set; }

        [Column("IdFornecedor")]
        public int IdFornecedor { get; set; }

        [Column("DataContato")]
        public DateTime DataContato { get; set; }

        [Column("Mensagem")]
        public string Mensagem { get; set; }
    }
}
