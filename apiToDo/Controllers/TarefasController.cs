using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        [Authorize]
        [HttpGet("lstTarefas")]
        // aqui eu alterei o [Post] para [Get]
        public ActionResult lstTarefas()
        {
            try
            {
                Tarefas classeTarefas = new Tarefas();       
                

                return Ok(classeTarefas);
            }

            catch (Exception ex)    
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpPost("InserirTarefas")] 
        //aqui mantive o Post pois você solicita Inserir a tarefa
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas classeInserirTarefas = new Tarefas();
                classeInserirTarefas.InserirTarefa(Request);
                return Ok(classeInserirTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        //aqui alterei de [Get] para [Delete] pois solicita deletar
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                Tarefas classeDeletarTarefa = new Tarefas();
                classeDeletarTarefa.DeletarTarefa(ID_TAREFA);

                return StatusCode(200, new {msg = "Tafera deletada com sucesso"});
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
