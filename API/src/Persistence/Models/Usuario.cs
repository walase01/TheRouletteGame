using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public int Monto { get; set; }
    }
}
