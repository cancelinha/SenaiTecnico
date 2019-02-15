using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SVIGUFO.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set; }

        public string Nome_Fantasia { get; set; }

        public string Razao_Social { get; set; }

        public string CNPJ { get; set; }

        public string Logradouro {get; set;}

        public string CEP { get; set; }

        public string UF { get; set; }

        public string Cidade { get; set; }
    }
}
