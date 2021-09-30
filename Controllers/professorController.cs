using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Data;
using TCS_Projeto_API.Model;
using TCS_Projeto_API.Services.Interface;

namespace TCS_Projeto_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class professorController : Controller
    {
        private readonly IProfessorMenu _context;

        public professorController(IProfessorMenu context)
        {
            _context = context;
        }

        [HttpGet("ListaProfessor")]
        public IActionResult GetProfessores()
        {
            var model = _context.GetProfessores();
            return Ok(model);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Create(Professor professor)
        {
            try
            {
                _context.Add(professor);
                await (_context.SaveChangeProfessor());

                return Ok(professor);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro em ProfessorController/Create: {e.Message}");
            }
        }

        [HttpPost("atualizar/{id}")]
        public async Task<IActionResult> Update(Professor professor, int id)
        {
            try
            {
                Professor antigoProfessor = _context.GetProfessorById(id);

                if (antigoProfessor == null)
                {
                    return BadRequest("Erro: Professor não encontrado");
                }
                else
                {
                    antigoProfessor = _context.GetProfessorById(id);
                }

                antigoProfessor.Nome = professor.Nome;
                antigoProfessor.Email = professor.Email;
                antigoProfessor.Senha = professor.Senha;

                _context.Update(antigoProfessor);
                await (_context.SaveChangeProfessor());

                return Ok(antigoProfessor);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro em ProfessorController/Update: {e.Message}");
            }
        }

        [HttpPut("atualizar/{id}/deletar")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Professor deletarProfessor = _context.GetProfessorById(id);

                if (_context.GetProfessorById(id) == null)
                {
                    return BadRequest("Erro: Professor não encontrado");
                }
                else
                {
                    deletarProfessor = _context.GetProfessorById(id);
                }

                deletarProfessor.Esconder();

                _context.Update(deletarProfessor);
                await (_context.SaveChangeProfessor());

                return Ok(deletarProfessor);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro em ProfessorController/Delete: {e.Message}");
            }
        }
    }
}
