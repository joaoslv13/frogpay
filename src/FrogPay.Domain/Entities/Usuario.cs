using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Domain.Entities
{
    public sealed class Usuario : BaseEntity
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
    }
}
