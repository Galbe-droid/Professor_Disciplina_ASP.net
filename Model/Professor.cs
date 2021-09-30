using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCS_Projeto_API.Model
{
    public class Professor
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Senha { get; set; }

        public bool FoiExcluido { get; set; }

        public Professor() { }

        public Professor(int id, string nome, string email, string senha)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.FoiExcluido = false;
        }

        public bool Esconder()
        {
            return this.FoiExcluido = true;
        }
    }
}
