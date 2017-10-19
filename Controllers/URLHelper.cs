﻿using System;
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

            url = url.Replace("{RAMAL}", ligacao.Telefone);
            url = url.Replace("{FONE}", ligacao.Fila.Ramal);

            return url;

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