using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualRunner.Data;
using VirtualRunner.Data.Entities;

namespace VirtualRunner.Services
{
    public class DoacaoService : IDoacaoService
    {
        private VirtualRunnerDbContext _ctx;

        public DoacaoService(VirtualRunnerDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Doar(RegistroRunner runner)
        {
            _ctx.RegistrosRunners.Add(runner);
            _ctx.SaveChanges();
        }
    }
}
