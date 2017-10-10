using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ligueme.Models
{
    public class Fila
    {

        public Fila()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public string Ramal { get; set; }
        public string Descricao { get; set; }


    }
}