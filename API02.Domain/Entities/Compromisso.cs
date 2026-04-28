using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Domain.Entities
{
    public class Compromisso
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public string Descricao { get; set; }

        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
