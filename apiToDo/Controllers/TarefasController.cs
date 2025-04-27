using Api.ToDo.Repository.Context;
using Api.ToDo.Repository.DTOs;
using Api.ToDo.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly TaskRepository _TaskRepository;
        public TarefasController()
        {
            _TaskRepository = new TaskRepository(new TaskContext());
        }

        [HttpGet("ListaTarefas")]
        public ActionResult ListTasks()
        {
            try
            {
                var lstTasks = _TaskRepository.GetAllTask();
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
                var lstTasks = _TaskRepository.InsertTask(request);
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
                var lstTasks = _TaskRepository.DeleteTask(ID_TAREFA);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
        [HttpGet("{Id}")]
        public ActionResult GetByIdTask([FromRoute] int Id)
        {
            try
            {

                var lstTasks = _TaskRepository.GetTaskByID(Id);
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
                var lstTasks = _TaskRepository.UpdateTask(request);
                return StatusCode(200, lstTasks);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
