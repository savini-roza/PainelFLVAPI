using PainelFLVAPI.Model.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PainelFLVAPI.Model
{

    [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Senha")]
        public string Senha { get; set; }

        [Column("Ativo")]
        public sbyte Ativo { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        [Column("TipoUsuario")]
        public char TipoUsuario { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

        [Column("Logradouro")]
        public string Logradouro { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Cep")]
        public string Cep { get; set; }

        [Column("Numero")]
        public string Numero { get; set; }

        [Column("Complemento")]
        public string Complemento { get; set; }

        [Column("UrlFoto")]
        public string? UrlFoto { get; set;  }
    }
}
