using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ligueme.Models;
using Ligueme.Models.Context;

namespace Ligueme.Controllers
{
    public class TesteController : ApiController
    {
        // GET api/<controller>
        [AcceptVerbs("GET")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<Ligacao> Get(int id)
        {
            LigueMeContext context = new LigueMeContext();
            return context.Ligacoes;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}