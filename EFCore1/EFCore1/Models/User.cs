using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore1.Models
{
    public class User
    {
        public int Id { get; set; } // первичный ключ
        public string? Name { get; set; } // прочие поля
        public int Age { get; set; }
    }
}
