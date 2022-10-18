using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using System.Threading.Tasks;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Arma p = await _context.Armas
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Arma> lista = await _context.Armas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("Dano não pode ser maior que 100");
                }
                Personagem p = await _context.Personagens
                    .FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);
                    
                if(p == null)
                    throw new System.Exception("Não existe personagem com o Id informado. ");

                await _context.Armas.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new Exception("Dano não pode ser maior que 100");
                }
                _context.Armas.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Arma pRemover = await _context.Armas
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.Armas.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}