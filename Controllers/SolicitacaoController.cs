using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ligueme.Models;

namespace Ligueme.Controllers
{
    public class SolicitacaoController : ApiController
    {
        public IEnumerable<Solicitacao> Get()
        {

            List<Solicitacao> lista = new List<Solicitacao>();

            Solicitacao s1 = new Solicitacao();
            s1.numero = "8888888";
            s1.fila = "55s44s88";
            lista.Add(s1);

            return lista;
        }

    }
}