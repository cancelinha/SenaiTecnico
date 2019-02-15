using Microsoft.AspNetCore.Mvc;
using Senai.SVIGUFO.WebApi.Domains;
using Senai.SVIGUFO.WebApi.Interfaces;
using Senai.SVIGUFO.WebApi.Repositorios;
using System.Collections.Generic;

namespace Senai.SVIGUFO.WebApi.Controllers
{
    [Route("Api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TiposEventosController : ControllerBase
    {
        // lista estatica
        List<TipoEventoDomain> Tiposeventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain {Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain {Id = 2, Nome = "Redes"},
            new TipoEventoDomain {Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain {Id = 4, Nome = "Marketing"}
        };
        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }


        [Produces("application/json")]
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {

            return TipoEventoRepository.Listar();
        }
        //    <summary>
        //<param name="id"></param>
        //<retorna um tipo de evento/>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {  
            //busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEvento = Tiposeventos.Find(x => x.Id == Id);
            //verifica se foi encontrado na lista o tipo de evento
            if (tipoEvento == null) {
                //retorna nao encontrado
                return NotFound();
            }


            //retorna ok e tipo de evento
            return Ok(tipoEvento);
        }
        [HttpPost] //verbo para inserir
        public IActionResult Post(/*[FromBody]*/TipoEventoDomain tipoEventoRecebido)
        {
           Tiposeventos.Add(new TipoEventoDomain{
                Id = Tiposeventos.Count +1,
                Nome = tipoEventoRecebido.Nome

            });
            //retorna ok e a lista com os tipos de eventos
            return Ok(Tiposeventos);
        }

        [HttpPut]// verbo para atualizar
        public IActionResult Put(TipoEventoDomain tipoEventoRecebido)
        {
            TipoEventoRepository.Alterar(tipoEventoRecebido);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, TipoEventoDomain tipoEventoRecebido)
        //{
        //    return Ok();
        //}

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            //Tiposeventos.Remove(Tiposeventos.Find(x => x.Id == id));
            TipoEventoRepository.Deletar(id);
            return Ok(Tiposeventos);
        }
        //[HttpGet]
        //public string Get()
        //{
        //    return "Recebi sua Requisição";
        //}
    }
}