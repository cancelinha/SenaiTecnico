using Senai.SVIGUFO.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SVIGUFO.WebApi.Interfaces
{
    interface ITipoEventoRepository
    {
        ///<summary>
        ///Lista todos os tipos de eventos
        ///</summary>summary>
        ///<returns> Retorna uma lista </returns>
        List<TipoEventoDomain> Listar();

        void Cadastrar(TipoEventoDomain tipoEvento);

        void Alterar(TipoEventoDomain tipoEvento);

        void Deletar(int id);
    }
}
