using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Model;
using TCS_Projeto_API.Services.Interface;

namespace TCS_Projeto_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class disciplinaController : Controller
    {
        private readonly IDisciplinaMenu _context;

        public disciplinaController(IDisciplinaMenu context)
        {
            _context = context;
        }

        [HttpGet("ListaDisciplina")]
        public async Task<IActionResult> GetListaDisciplina()
        {
            var model = _context.GetDisciplinas();

            return Ok(model);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Create(Disciplina disciplina)
        {            
            try
            {
                _context.Add(disciplina);
                await (_context.SaveChangesDisciplina());

                return Ok(disciplina);
            }
            catch(Exception e)
            {
                return BadRequest($"Erro em DisciplinaCadastro/Create: {e.Message}");
            }
        }

        [HttpPost("atualizar/{id}")]
        public async Task<IActionResult> Update(Disciplina disciplina, int id)
        {
            try
            {
                Disciplina oldDisicplina;
                if(_context.GetDsiciplinaById(id) == null)
                {
                    return BadRequest($"Erro: Disciplina não encotrado.");
                }
                else
                {
                    oldDisicplina = _context.GetDsiciplinaById(id);
                }

                oldDisicplina.Nome = disciplina.Nome;
                oldDisicplina.CargaHoraria = disciplina.CargaHoraria;

                _context.Update(oldDisicplina);
                await (_context.SaveChangesDisciplina());

                return Ok(oldDisicplina);
            }
            catch(Exception e)
            {
                return BadRequest($"Erro em dsiciplinaCadastro/Update: {e.Message}");
            }
        }

        [HttpPut("atualizar/{id}/deletar")]
        public async Task<IActionResult> Delete(int id)
        {
            Disciplina deleteDisciplina;
            if(_context.GetDsiciplinaById(id) == null)
            {
                return BadRequest($"Erro: disciiplina não encotrada");
            }
            else
            {
                deleteDisciplina = _context.GetDsiciplinaById(id);
            }

            deleteDisciplina.Esconder();

            _context.Update(deleteDisciplina);
            await (_context.SaveChangesDisciplina());

            return Ok(deleteDisciplina);
        }
    }
}
