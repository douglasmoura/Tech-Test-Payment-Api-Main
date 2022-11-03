using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Test_Payment_Api_Main.Models
{
    [Table("tb_vendedores")]
    public class Vendedor
    {
        public int Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("email")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Column("cpf")]
        [Required]
        [StringLength(15)]
        public string Cpf { get; set; }

        [Column("telefone")]
        [StringLength(20)]
        public string Telefone { get; set; }
    }
}