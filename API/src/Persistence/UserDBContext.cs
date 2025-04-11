using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence
{
    public class UserDBContext : DbContext
    {
        public UserDBContext() { }

        public UserDBContext(DbContextOptions options) : base(options) { }
        
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }

}
