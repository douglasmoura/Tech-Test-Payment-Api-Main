using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tech_Test_Payment_Api_Main.Context;
using Tech_Test_Payment_Api_Main.Models;

namespace Tech_Test_Payment_Api_Main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ProdutoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {   //Com o Serviço do identity
                if (produto is null)
                {
                    return StatusCode(400);
                }

                _dbContext.Add(produto);
                _dbContext.SaveChanges();

                return StatusCode(201, produto);
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
                var produtos = _dbContext.Produtos;
                return StatusCode(200, produtos);
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
                var produto = _dbContext.Produtos.Find(id);

                if (produto is null)
                {
                    return StatusCode(401);
                }

                return StatusCode(200, produto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Produto produto)
        {
            try
            {   
                var produtoDb = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

                if (produtoDb is null)
                {
                    return StatusCode(400);
                }

                produtoDb.Nome = produto.Nome;
                produtoDb.Preco = produto.Preco;
            
                _dbContext.Update(produtoDb);
                _dbContext.SaveChanges();

                return StatusCode(200, produtoDb);
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

                var produto = _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

                if (produto is null) return StatusCode(404);

                _dbContext.Produtos.Remove(produto);
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