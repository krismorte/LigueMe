using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ligueme.Models;

namespace Ligueme.Controllers
{
    public class URLHelper
    {

        public static string URLCamedLog(IEnumerable<Parametros> _parametros)
        {
            return Parametros.BuscarValor("URLLOG", _parametros);

        }

        public static string URLCentralTelefonica(IEnumerable<Parametros> _parametros, Ligacao ligacao)
        {
            string url = Parametros.BuscarValor("URL", _parametros);

            url = url.Replace("{RAMAL}",ligacao.Fila.Ramal );
            url = url.Replace("{FONE}", ligacao.Telefone);

            return url;

        }

        public static bool ProxyEnabled(IEnumerable<Parametros> _parametros)
        {
            string answer = Parametros.BuscarValor("PROXYENABLE", _parametros);
            if (answer == "YES")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string URLGoogleCaptch(IEnumerable<Parametros> _parametros,string response)
        {

            string urlCaptcha = Parametros.BuscarValor("URLCAPTCHA", _parametros);
            string keyCaptcha = Parametros.BuscarValor("CAPTCHASSECRETkEY", _parametros);

            //solicitacao.secret = keyCaptcha;

            urlCaptcha = urlCaptcha.Replace("{SECRET}", keyCaptcha);
            urlCaptcha = urlCaptcha.Replace("{RESPONSE}", response);

            return urlCaptcha;

        }

    }
}