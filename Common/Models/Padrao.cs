using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Padrao : BaseModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ferramental { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
