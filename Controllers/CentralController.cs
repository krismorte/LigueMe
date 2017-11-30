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
using Newtonsoft.Json;
using System.Text;
using System.Net;
using System.IO;

namespace Ligueme.Controllers
{
    public class CentralController : ApiController
    {
        private readonly LigueMeContext _context;
        private readonly IEnumerable<Parametros> _parametros;
        private Solicitacao solicitacao;
        private string errorMsgCaptcha;

        public CentralController()
        {
            _context = new LigueMeContext();
            _parametros = _context.Parametros;
        }

        [HttpPost]
        public Ligacao adicionaLigacao([FromBody]Solicitacao solicitacaoJson)
        {
            solicitacao = solicitacaoJson;

            Ligacao ligacao = new Ligacao();

            if (ValidarCaptcha())
            {
                try
                {
                    ligacao.DDD = Parametros.BuscarValor("DDD", _parametros);
                    ligacao.adicionaNumero(solicitacao.numero);
                    ligacao.Fila = BuscarFila(solicitacao.fila);

                    ChamaURLCentralTelefonica(ligacao);
                    RegistraLigacao(ligacao);
                    addLogMessage(1, "Ligação solicitada: " + ligacao.Telefone, "");
                }
                catch (Exception ex)
                {
                    addLogMessage(3, ex.Message, "");
                    //throw ex;
                }
            }
            else
            {
                addLogMessage(1, "ErrorCaptcha: " + ligacao.Telefone, errorMsgCaptcha);
                errorMsgCaptcha = "";
            }

            return ligacao;
        }


        private bool ValidarCaptcha()
        {
            string responseFromServer = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URLHelper.URLGoogleCaptch(_parametros, solicitacao.response));
            req.Proxy = GetWebProxy();

            using (WebResponse resp = req.GetResponse())
            using (Stream dataStream = resp.GetResponseStream())
            {
                if (dataStream != null)
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        // Read the content.
                        responseFromServer = reader.ReadToEnd();
                    }
                }
            }


            dynamic jsonResponse = new JavaScriptSerializer().DeserializeObject(responseFromServer);

            bool catptchaOk = jsonResponse == null || bool.Parse(jsonResponse["success"].ToString());

            if (catptchaOk)
            {
                return catptchaOk;
            }
            else
            {
                GetErroCaptch(jsonResponse);
                return catptchaOk;
            }

        }


        private void ChamaURLCentralTelefonica(Ligacao ligacao)
        {
            new HttpClient().PostAsync(URLHelper.URLCentralTelefonica(_parametros, ligacao), null);
        }

        private void addLogMessage(int level, string message, string data)
        {
            Log logMensage = new Log();
            logMensage.level = level;
            logMensage.message = message;
            logMensage.data = data;

            new HttpClient().PostAsJsonAsync(URLHelper.URLCamedLog(_parametros), logMensage);
        }

        private WebProxy GetWebProxy()
        {
            return new WebProxy(Parametros.BuscarValor("PROXYSERVER", _parametros)
                , Int16.Parse(Parametros.BuscarValor("PROXYPORT", _parametros)));
        }

        private void GetErroCaptch(dynamic jsonResponse)
        {
            IList list = (IList)jsonResponse["error-codes"];

            foreach (Object o in list)
            {
                errorMsgCaptcha += o.ToString();
            }
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

    }
}