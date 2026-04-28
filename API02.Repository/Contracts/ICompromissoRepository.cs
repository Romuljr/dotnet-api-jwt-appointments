using API02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Contracts
{
    public interface ICompromissoRepository 
        : IBaseRepository<Compromisso>
    {
        List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId);
    }
}
