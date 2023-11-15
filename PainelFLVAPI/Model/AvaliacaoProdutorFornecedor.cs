﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("AvaliacaoProdutorFornecedor", Schema = "dbo")]

    public class AvaliacaoProdutorFornecedor
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdFornecedor")]
        public int IdFornecedor { get; set; }

        [Column("IdProdutor")]
        public int IdProdutor { get; set; }

        [Column("Nota")]
        public double Nota { get; set; }

        [Column("Comentario")]
        public string Comentario { get; set; }

        [Column("DataAvaliacao")]
        public DateTime DataAvaliacao { get; set; }

        [Column("Resposta")]
        public string Resposta { get; set; }

        [Column("DataResposta")]
        public DateTime DataResposta { get; set; }
    }
}
