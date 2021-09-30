using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCS_Projeto_API.Model;

namespace TCS_Projeto_API.Services.Interface
{
    public interface IProfessorMenu
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeProfessor();
        List<Professor> GetProfessores();
        Professor GetProfessorByName(string nomeProfessor);
        Professor GetProfessorById(int id);
    }
}
