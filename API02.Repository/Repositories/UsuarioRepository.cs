using API02.Domain.Entities;
using API02.Infra.Contexts;
using API02.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API02.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlServerContext context;

        public UsuarioRepository(SqlServerContext context) : base(context) 
        {
            this.context = context;
        }

        public Usuario Get(string email)
        {
            return context.Usuario
                .Where(u => u.Email.Equals(email))
                .FirstOrDefault();
        }

        public Usuario Get(string email, string senha)
        {
            return context.Usuario
                .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                .FirstOrDefault(); 
        }
    }
}
