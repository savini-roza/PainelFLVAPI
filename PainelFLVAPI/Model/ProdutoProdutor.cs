using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("ProdutoProdutor", Schema = "dbo")]
    [Keyless]
    public class ProdutoProdutor
    {
        [Column("IdProduto")]
        public int IdProduto { get; set; }

        [Column("IdProdutor")]
        public int IdProdutor { get; set; }

        [Column("Unidade")]
        public string? Unidade { get; set; }

        [Column("Preco")]
        public double Preco { get; set; }
    }
}
