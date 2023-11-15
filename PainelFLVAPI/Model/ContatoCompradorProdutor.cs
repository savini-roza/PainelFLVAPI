using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("ContatoCompradorProdutor", Schema = "dbo")]
    public class ContatoCompradorProdutor
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdComprador")]
        public int IdComprador { get; set; }

        [Column("IdProdutor")]
        public int IdProdutor { get; set; }

        [Column("DataContato")]
        public DateTime DataContato { get; set; }

        [Column("Mensagem")]
        public string Mensagem { get; set; }
    }
}
