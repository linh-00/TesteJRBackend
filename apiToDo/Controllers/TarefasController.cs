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
        private readonly Tasks _TaskModels;
        public TarefasController()
        {
            _TaskModels = new Tasks();
        }

        [HttpGet("ListaTarefas")]
        public ActionResult ListTasks()
        {
            try
            {
                var lstTasks = _TaskModels.ListTask();
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
                var lstTasks = _TaskModels.InsertTask(request);
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
                var lstTasks = _TaskModels.DeleteTask(ID_TAREFA);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetByIdTask([FromRoute] int Id)
        {
            try
            {

                var lstTasks = _TaskModels.GetTaskByID(Id);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [HttpPut("AtualizaçãoTarefas")]
        public ActionResult UpdateTasks([FromBody] TaskDTO request)
        {
            try
            {
                var lstTasks = _TaskModels.UpdateTask(request);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
