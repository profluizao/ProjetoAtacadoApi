﻿using Atacado.Poco.RH;
using Atacado.Service.RH;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// Recurso Funcionário.
    /// </summary>
    [Route("api/rh/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public FuncionarioController() : base()
        {
            this.servico = new FuncionarioService();
        }

        /// <summary>
        /// Realiza a busca por todos os registros, filtrando onde inicia (skip) e a quantidade(take).
        /// </summary>
        /// <param name="skip">Onde inicia os resultados da pesquisa.</param>
        /// <param name="take">Quantos registros serão retornados.</param>
        /// <returns>Coleção de dados.</returns>
        [HttpGet("{skip:int}/{take:int}")]
        public ActionResult<List<FuncionarioPoco>> GetAll(int skip, int take)
        {
            try
            {
                List<FuncionarioPoco> listaResposta = this.servico.Listar(skip, take);
                return Ok(listaResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public ActionResult<FuncionarioPoco> Get(int id)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Selecionar(id);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        [HttpGet("matricula/{mat:long}")]
        public ActionResult<FuncionarioPoco> GetPorMatricula(long mat)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.SelecionarPorMatricula(mat);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<FuncionarioPoco> Post([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Criar(poco);
                if (pocoResposta == null)
                {
                    return BadRequest(this.servico.MensagensProcessamento);
                }
                else
                {
                    return Ok(pocoResposta);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<FuncionarioPoco> Put([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Atualizar(poco);
                if (pocoResposta == null)
                {
                    return BadRequest(this.servico.MensagensProcessamento);
                }
                else
                {
                    return Ok(pocoResposta);
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<FuncionarioPoco> Delete([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Excluir(poco);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public ActionResult<FuncionarioPoco> Delete(int id)
        {
            try
            {
                FuncionarioPoco pocoResposta = this.servico.Excluir(id);
                return Ok(pocoResposta);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
