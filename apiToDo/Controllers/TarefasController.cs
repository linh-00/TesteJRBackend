using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                var LstTarefas = tarefas.lstTarefas();
                return StatusCode(200, LstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                var lstTarefas = tarefas.InserirTarefa(Request);
                return StatusCode(200, lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                Tarefas tarefas = new Tarefas();
                var lstTarefas = tarefas.DeletarTarefa(ID_TAREFA);
                return StatusCode(200, lstTarefas);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
