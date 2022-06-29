using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atacado.EF.Database
{
    [Table("EMPRESA")]
    public partial class Empresa
    {
        [Key]
        [Column("ID_Empresa")]
        public int Codigo { get; set; }

        [Column("RAZAOSOCIAL")]
        [Unicode(false)]
        public string RazaoSocial { get; set; }

        [Column("NOMEFANTASIA")]
        [Unicode(false)]
        public string NomeFantasia { get; set; }

        [Column("CNPJ")]
        [Unicode(false)]
        public string Cnpj { get; set; }
        
        [Column("INSCRICAOESTADUAL")]
        [Unicode(false)]
        public string InscricaoEstadual { get; set; }
        
        [Column("TELEFONE")]
        [Unicode(false)]
        public string Telefone { get; set; }
        
        [Column("EMAIL")]
        [Unicode(false)]
        public string Email { get; set; }
        
        [Column("ENDERECO")]
        [Unicode(false)]
        public string Endereco { get; set; }
    }
}
