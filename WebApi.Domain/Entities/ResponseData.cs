using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WebApi.Domain.Entities
{
    /// <summary>
    /// ResponseData.
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// Obtém ou define a mensagem do erro.
        /// </summary>
        [DataMember(Name = "mensagem")]
        public string Mensagem { get; set; }
    }
}
