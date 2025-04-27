using Api.ToDo.Repository.Context;
using Api.ToDo.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.ToDo.Repository.Models
{
    public class TaskRepository
    {
        private readonly TaskContext _Context;

        public TaskRepository(TaskContext context)
        {
            _Context = context;
        }

        public List<TaskDTO> GetAllTask()
        {
            try
            {
                return _Context.LstTasks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir sua tarefa, tente novamente mais tarde, Message:{ex.Message}");
            }
        }

        public List<TaskDTO> InsertTask(TaskDTO Request)
        {
            try
            {
                _Context.LstTasks.Add(Request);
                return _Context.LstTasks;
            }
            catch (Exception ex)
            {
                throw new Exception($"Não foi possível inserir sua tarefa, tente novamente mais tarde, Message:{ex.Message}");
            }
        }
        public List<TaskDTO> DeleteTask(int ID_TAREFA)
        {
            //Buscando informação da lista Tarefas
            List<TaskDTO> lstResponse = _Context.LstTasks;
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

        public TaskDTO GetTaskByID(int Id)
        {
            TaskDTO task = _Context.LstTasks.Where(x => x.ID_TAREFA == Id).FirstOrDefault();
            if (task is null)
            {
                throw new Exception("Tarefa não encontrada, Message");
            }
            return task;
        }

        public List<TaskDTO> UpdateTask(TaskDTO request)
        {
            TaskDTO task = _Context.LstTasks.Where(x => x.ID_TAREFA == request.ID_TAREFA).FirstOrDefault();
            if (task is not null)
            {
                task.DS_TAREFA = request.DS_TAREFA;
            }
            return _Context.LstTasks;
        }
    }
}
