using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tech_Test_Payment_Api_Main.Models.Enums;

namespace Tech_Test_Payment_Api_Main.Models
{
    [Table("tb_venda")]
    public class Venda
    {
        public int Id { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }
        [Column("data")]
        public DateTime Data { get; set; }
        public List<Produto> Produtos { get; set; }
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        
        [Column("status_da_venda")]
        public StatusDaVenda StatusDaVenda { get; set; }
    }
}