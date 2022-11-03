using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tech_Test_Payment_Api_Main.Models
{
    [Table("tb_produto")]
    public class Produto
    {
        public int Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("preco")]
        public double Preco { get; set; }
    }
}