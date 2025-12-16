using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class AlunosDisciplinas
    {
        [Key]
        public int id { get; set; }

        public int idDisc { get; set; }
        [ForeignKey("idDisc")]
        public virtual Disciplinas Disciplinas { get; set; }

        public int idAluno { get; set; }
        [ForeignKey("idAluno")]
        public virtual Alunos Alunos { get; set; }
    }
}