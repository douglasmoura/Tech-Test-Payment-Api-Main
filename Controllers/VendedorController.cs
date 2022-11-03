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
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public VendedorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Post(Vendedor vendedor)
        {
            try
            {   //Com o Serviço do identity
                if (vendedor is null)
                {
                    return StatusCode(400);
                }

                _dbContext.Add(vendedor);
                _dbContext.SaveChanges();

                return StatusCode(201, vendedor);
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
                var vendedores = _dbContext.Vendedores;
                return StatusCode(200, vendedores);
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
                var vendedor = _dbContext.Vendedores.Find(id);

                if (vendedor is null)
                {
                    return StatusCode(401);
                }

                return StatusCode(200, vendedor);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Vendedor vendedor)
        {
            try
            {   
                var vendedorDb = _dbContext.Vendedores.Find(id);

                if (vendedorDb is null)
                {
                    return StatusCode(400);
                }

                vendedorDb.Nome = vendedor.Nome;
                vendedorDb.Cpf = vendedor.Cpf;
                vendedorDb.Email = vendedor.Email;
                vendedorDb.Telefone = vendedor.Telefone;

                _dbContext.Update(vendedorDb);
                _dbContext.SaveChanges();

                return StatusCode(200, vendedorDb);
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

                var vendedor = _dbContext.Vendedores.FirstOrDefault(l => l.Id == id);

                if (vendedor is null) return StatusCode(404);

                _dbContext.Vendedores.Remove(vendedor);
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