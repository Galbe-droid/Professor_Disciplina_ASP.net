using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TCS_Projeto_API.Model
{
    public class Disciplina
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public int CargaHoraria { get; set; }

        [Required]
        public bool FoiDeletado { get; set; }

        public Disciplina() { }

        public Disciplina(int id, string nome, int cargaHoraria)
        {
            this.Id = id;
            this.Nome = nome;
            this.CargaHoraria = cargaHoraria;
            this.FoiDeletado = false;
        }

        public bool Esconder()
        {
            return this.FoiDeletado = true;
        }
    }
}
