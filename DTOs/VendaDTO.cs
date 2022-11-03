using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tech_Test_Payment_Api_Main.Models.Enums;

namespace Tech_Test_Payment_Api_Main.DTOs
{
    public class VendaDTO
    {
        public string Nome { get; set; }
        public List<int> ProdutoIds { get; set; }
        public int VendedorId { get; set; }
        public StatusDaVenda StatusDaVenda { get; set; }
    }
}