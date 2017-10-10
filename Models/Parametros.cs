using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ligueme.Models
{
    public class Parametros
    {

        public Parametros()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }

        public static string BuscarValor(string Chave, IEnumerable<Parametros> _parametros)
        {
            string valor = "";
            foreach (Parametros parametro in _parametros)
            {
                if (parametro.Chave == Chave)
                {
                    valor = parametro.Valor;
                    break;
                }
            }
            return valor;

        }

    }
}