using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tasks
    {
        private readonly List<TaskDTO> LstTasks;

        public Tasks()
        {
            LstTasks = new List<TaskDTO>()
            {
                new TaskDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                },

                new TaskDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividades Faculdade"
                },

                new TaskDTO
                {
                    ID_TAREFA = 3,
                    DS_TAREFA = "Subir Projeto de Teste no Github"
                },
            };

        }
        public List<TaskDTO> ListTask() => LstTasks;

        public List<TaskDTO> InsertTask(TaskDTO Request)
        {
            try
            {
                LstTasks.Add(Request);
                return LstTasks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir sua tarefa, tente novamente mais tarde, Message:{ex.Message}");
            }
        }
        public List<TaskDTO> DeleteTask(int ID_TAREFA)
        {
            //Buscando informação da lista Tarefas
            List<TaskDTO> lstResponse = LstTasks;
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
