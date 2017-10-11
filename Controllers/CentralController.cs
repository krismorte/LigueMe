using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ligueme.Models;
using Ligueme.Models.Context;
using System.Net.Http;
using System.Collections;
using System.Web.Script.Serialization;

namespace Ligueme.Controllers
{
    public class CentralController : ApiController
    {
        private readonly LigueMeContext _context;
        private readonly IEnumerable<Parametros> _parametros;
        
        public CentralController()
        {
            _context = new LigueMeContext();
            _parametros = _context.Parametros;
        }

        [HttpPost]
        public Ligacao adicionaLigacao([FromBody]Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
            }
            Ligacao ligacao = new Ligacao();

            try
            {
                ligacao.DDD = Parametros.BuscarValor("DDD", _parametros);
                ligacao.adicionaNumero(solicitacao.numero);
                ligacao.Fila = BuscarFila(solicitacao.fila);

                ChamaURLCentralTelefonica(ligacao);
                RegistraLigacao(ligacao);
                addLogMessage(1, "Ligação solicitada: " + ligacao.Telefone);
            }
            catch (Exception ex)
            {
                addLogMessage(3, ex.Message);
                throw ex;
            }
                        
            return ligacao;

        }

        private Fila BuscarFila(string ID)
        {
            return _context.Filas.Find(Guid.Parse(ID));
        }

        private void RegistraLigacao(Ligacao ligacao)
        {
            _context.Ligacoes.Add(ligacao);
            _context.SaveChanges();
        }

        private void ChamaURLCentralTelefonica(Ligacao ligacao)
        {
            string url = Parametros.BuscarValor("URL", _parametros);
            url = url.Replace("{RAMAL}", ligacao.Fila.Ramal);
            url = url.Replace("{FONE}", ligacao.Telefone);

            new HttpClient().PostAsync(url, null);
        }

        private void addLogMessage(int level,string message)
        {
            string url = Parametros.BuscarValor("URLLOG", _parametros);
            
            Log logMensage = new Log();
            logMensage.level=level;
            logMensage.message=message;
            logMensage.data= "";
         
            new HttpClient().PostAsJsonAsync(url, logMensage);           
        }

    }
}