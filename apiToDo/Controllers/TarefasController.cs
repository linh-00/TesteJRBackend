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
        [HttpGet("ListaTarefas")]
        public ActionResult ListTasks()
        {
            try
            {
                Tasks tasks = new Tasks();
                var lstTasks = tasks.GetAllTasks();
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InsertTasks([FromBody] TaskDTO request)
        {
            try
            {
                Tasks tasks = new Tasks();
                var lstTasks = tasks.InsertTask(request);
                return StatusCode(200, lstTasks);
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
                Tasks tasks = new Tasks();
                var lstTasks = tasks.DeleteTask(ID_TAREFA);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
