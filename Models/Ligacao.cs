using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ligueme.Models
{
    public class Ligacao
    {
        public string DDD = "021";

        public Ligacao()
        {
            ID = Guid.NewGuid();
            DataHora = DateTime.Now;
        }

        public Guid ID { get; set; }
        public DateTime DataHora { get; set; }
        public string Telefone { get; set; }

        public Fila Fila { get; set; }
        public Nullable<System.Guid> FilaID { get; set; }

        public void adicionaNumero(string numero)
        {
            numero = numero.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

            if (numero.Length < 8)
            {
                throw new System.ArgumentException("Número inválido!", "NUMERO");
            }else if (numero.Length > 13)
            {
                Telefone = DDD + numero;
            }
            else
            {
                Telefone = numero;
            }
        }

    }
}