using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ligueme.Models
{
    public class Solicitacao
    {
        [Required][MinLength(9)]
        public string numero { get; set; }
        public string fila { get; set; }

    }
}