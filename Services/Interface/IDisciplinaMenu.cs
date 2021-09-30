using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Model;

namespace TCS_Projeto_API.Services.Interface
{
    public interface IDisciplinaMenu
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesDisciplina();
        List<Disciplina> GetDisciplinas();
        Disciplina GetDisciplinaByName(string nomeDisciplina);
        Disciplina GetDsiciplinaById(int id);
    }
}
