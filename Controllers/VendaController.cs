using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tech_Test_Payment_Api_Main.Context;
using Tech_Test_Payment_Api_Main.DTOs;
using Tech_Test_Payment_Api_Main.Models;
using Tech_Test_Payment_Api_Main.Models.Enums;

namespace Tech_Test_Payment_Api_Main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public VendaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post(VendaDTO vendaDTO)
        {
            try
            {   //Com o Serviço do identity
                if (vendaDTO is null)
                {
                    return StatusCode(400);
                }

                var produtos = new List<Produto>();
                foreach (var produtoId in vendaDTO.ProdutoIds)
                {
                    var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == produtoId);
                    produtos.Add(produto);
                }

                var venda = new Venda(){
                    Nome = vendaDTO.Nome,
                    Data = DateTime.Now,
                    Produtos = produtos,
                    VendedorId = vendaDTO.VendedorId,
                    StatusDaVenda = vendaDTO.StatusDaVenda
                };

                _dbContext.Add(venda);
                _dbContext.SaveChanges();

                return StatusCode(201, venda);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {   //Com o Serviço do identity
                var vendas = _dbContext.Vendas.Include(v => v.Produtos).Include(v => v.Vendedor);
                return StatusCode(200, vendas);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {   //Com o Serviço do identity
                var venda = _dbContext.Vendas.Find(id);

                if (venda is null)
                {
                    return StatusCode(401);
                }

                return StatusCode(200, venda);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Venda venda)
        {
            try
            {   
                var vendaDb = _dbContext.Vendas.FirstOrDefault(p => p.Id == id);

                if (vendaDb is null)
                {
                    return StatusCode(400);
                }

                if (vendaDb.StatusDaVenda == StatusDaVenda.AguardandoPagamento
                    && (venda.StatusDaVenda == StatusDaVenda.PagamentoAprovado || 
                        venda.StatusDaVenda == StatusDaVenda.Cancelada))
                {
                    vendaDb.StatusDaVenda = venda.StatusDaVenda;
                }

                if (vendaDb.StatusDaVenda == StatusDaVenda.PagamentoAprovado
                    && (venda.StatusDaVenda == StatusDaVenda.EnviadoParaTransportadora || 
                        venda.StatusDaVenda == StatusDaVenda.Cancelada))
                {
                    vendaDb.StatusDaVenda = venda.StatusDaVenda;
                }

                if (vendaDb.StatusDaVenda == StatusDaVenda.EnviadoParaTransportadora
                    && venda.StatusDaVenda == StatusDaVenda.Entregue)
                {
                    vendaDb.StatusDaVenda = venda.StatusDaVenda;
                }

                vendaDb.Nome = venda.Nome;
                vendaDb.Data = DateTime.Now;
                vendaDb.Produtos = venda.Produtos;
                vendaDb.VendedorId = venda.VendedorId;
            
                _dbContext.Update(vendaDb);
                _dbContext.SaveChanges();

                return StatusCode(200, vendaDb);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 0) return StatusCode(404);

                var venda = _dbContext.Vendas.FirstOrDefault(p => p.Id == id);

                if (venda is null) return StatusCode(404);

                _dbContext.Vendas.Remove(venda);
                _dbContext.SaveChanges();
                
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}