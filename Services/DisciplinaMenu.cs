using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Data;
using TCS_Projeto_API.Model;
using TCS_Projeto_API.Services.Interface;

namespace TCS_Projeto_API.Services
{
    public class DisciplinaMenu : IDisciplinaMenu
    {
        private readonly DataContext _context;

        public DisciplinaMenu(DataContext context)
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

        public Disciplina GetDisciplinaByName(string nomeDisciplina)
        {
            return _context.disciplina.Where(obj => obj.Nome == nomeDisciplina && obj.FoiDeletado != true).FirstOrDefault();
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _context.disciplina.Where(obj => obj.FoiDeletado != true).ToList();
        }

        public Disciplina GetDsiciplinaById(int id)
        {
            return _context.disciplina.Where(obj => obj.Id == id && obj.FoiDeletado != true).FirstOrDefault();
        }

        public async Task<bool> SaveChangesDisciplina()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}
