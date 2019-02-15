using Senai.SVIGUFO.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SVIGUFO.WebApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<InstituicaoDomain> Listar();

        void Cadastrar(InstituicaoDomain Instituicao);

        void Alterar(InstituicaoDomain Instituicao);

        List<InstituicaoDomain> Buscar();

        void Delete(int Id);
    }
}
