using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Data;
using TCS_Projeto_API.Model;
using TCS_Projeto_API.Services.Interface;

namespace TCS_Projeto_API.Services
{
    public class ProfessorMenu : IProfessorMenu
    {
        private readonly DataContext _context;

        public ProfessorMenu(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            //Não se deve deletar diretamente infromações em programas comerciais
            _context.Update(entity);
        }

        public Professor GetProfessorById(int id)
        {
            return _context.professor.Where(obj => obj.Id == id && obj.FoiExcluido != true).FirstOrDefault();
        }

        public Professor GetProfessorByName(string nomeProfessor)
        {
            return _context.professor.Where(obj => obj.Nome == nomeProfessor && obj.FoiExcluido != true).FirstOrDefault();
        }

        public List<Professor> GetProfessores()
        {
            return _context.professor.Where(obj => obj.FoiExcluido != true).ToList();
        }

        public async Task<bool> SaveChangeProfessor()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
