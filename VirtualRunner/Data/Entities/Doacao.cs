using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualRunner.Data.Entities
{
    public class Doacao
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        public SituacaoPagamento SituacaoPagamento { get; set; }
    }
}
