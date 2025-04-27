using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tasks
    {
        public List<TaskDTO> GetAllTasks()
        {
            try
            {
                List<TaskDTO> lstTarefas = new List<TaskDTO>();

                lstTarefas.Add(new TaskDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TaskDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TaskDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no GitHub"
                });

                return lstTarefas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TaskDTO> InsertTask(TaskDTO Request)
        {
            try
            {
                List<TaskDTO> lstRequest = GetAllTasks();
                lstRequest.Add(Request);
                return lstRequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TaskDTO> DeletarTarefa(int ID_TAREFA)
        {
            //Buscando informação da lista Tarefas
            List<TaskDTO> lstResponse = GetAllTasks();
            //Buscando informações da tarefa pelo ID e armazenando na variável tarefa
            var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
            //Validando se a tarefa existe
            if (Tarefa is null)
            {
                //Retornando erro caso a tarefa não exista
                throw new Exception("Não foi possível deletar sua tarefa");
            }
            //Removendo a tarefa
            lstResponse.Remove(Tarefa);
            //Retornando uma lista com a tarefa removida
            return lstResponse;

        }
    }
}
