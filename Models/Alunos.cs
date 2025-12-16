using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Alunos
    {
        public int idAluno { get; set; }
        public String nomeAluno { get; set; }
        public virtual ICollection<AlunosDisciplinas> AlunosDisciplinas { get; set; }

    }
}