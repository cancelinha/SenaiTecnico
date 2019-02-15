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
    public class InstituicaoController : ControllerBase
    {

        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicaoController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }


        //[HttpGet("{Id}")]
        //public IActionResult BuscarPorId(int Id)
        //{

        //    InstituicaoRepository.Buscar();
        //    if (institu == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(institu);
        //}


        [HttpGet]
        public IEnumerable<InstituicaoDomain> Get()
        {

            return InstituicaoRepository.Listar();
        }
        
        [HttpPost] 
        
        public IActionResult Post(InstituicaoDomain instituicaoRecebido)
        {
            
            InstituicaoRepository.Cadastrar(instituicaoRecebido);
                       
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(InstituicaoDomain instituicaoRecebido)
        {
            InstituicaoRepository.Alterar(instituicaoRecebido);

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            InstituicaoRepository.Delete(id);

            return Ok();
        }
       
    }
}
