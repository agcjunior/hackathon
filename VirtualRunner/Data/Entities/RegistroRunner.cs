using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualRunner.Data.Entities
{
    public class RegistroRunner
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string GostaSerChamado { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }        

        public virtual ICollection<Doacao> Doacoes { get; set; }

        public RegistroRunner()
        {
            this.Doacoes = new List<Doacao>();
        }
        public void RegistrarDoacao(Doacao doacao)
        {
            this.Doacoes.Add(doacao);
        }
    }
}
