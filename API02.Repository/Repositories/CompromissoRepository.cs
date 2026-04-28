using API02.Domain.Entities;
using API02.Infra.Contexts;
using API02.Infra.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Repositories
{
    public class CompromissoRepository : BaseRepository<Compromisso>, ICompromissoRepository
    {
        private readonly SqlServerContext context;

        public CompromissoRepository(SqlServerContext context) : base(context)
        {
            this.context = context;
        }

        public List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            return context.Compromisso.Include(c => c.Usuario)
                .Where(c => c.Data >= dataMin && c.Data <= dataMax && c.UsuarioId == usuarioId)
                .OrderBy(c => c.Data)
                .ToList();
        }
    }
}
