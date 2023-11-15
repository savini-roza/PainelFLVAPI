using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("ProdutoComprador", Schema = "dbo")]
    [Keyless]
    public class ProdutoComprador
    {
        [Column("IdProduto")]
        public int IdProduto { get; set; }

        [Column("IdComprador")]
        public int IdComprador { get; set; }
    }
}
