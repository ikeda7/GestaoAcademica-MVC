using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Disciplinas
    {
        public int idDisc { get; set; }
        public String nomeDisciplina { get; set; }
        public virtual ICollection<AlunosDisciplinas> AlunosDisciplinas { get; set; }
    }
}