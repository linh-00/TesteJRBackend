using Api.ToDo.Repository.DTOs;
using System.Collections.Generic;

namespace Api.ToDo.Repository.Context
{
    public class TaskContext
    {
        public readonly List<TaskDTO> LstTasks;

        public TaskContext()
        {
            LstTasks = new List<TaskDTO>()
            {
                new TaskDTO()
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                },
                new TaskDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividade Faculdade"
                },
                new TaskDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                }
            };
        }
    }
}
