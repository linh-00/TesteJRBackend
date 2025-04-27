using apiToDo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiToDo.Models
{
    public class Tarefas
    {
        public List<TarefaDTO> lstTarefas()
        {
            try
            {
                List<TarefaDTO> lstTarefas = new List<TarefaDTO>();

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 1,
                    DS_TAREFA = "Fazer Compras"
                });

                lstTarefas.Add(new TarefaDTO
                {
                    ID_TAREFA = 2,
                    DS_TAREFA = "Fazer Atividad Faculdade"
                });

                lstTarefas.Add(new TarefaDTO
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
        public List<TarefaDTO> InserirTarefa(TarefaDTO Request)
        {
            try
            {
                List<TarefaDTO> lstRequest = lstTarefas();
                lstRequest.Add(Request);
                return lstRequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TarefaDTO> DeletarTarefa(int ID_TAREFA)
        {
            try
            {
                //Buscando informação da lista Tarefas
                List<TarefaDTO> lstResponse = lstTarefas();
                //Buscando informações da tarefa pelo ID e armazenando na variável tarefa
                var Tarefa = lstResponse.FirstOrDefault(x => x.ID_TAREFA == ID_TAREFA);
                //Removendo a tarefa
                lstResponse.Remove(Tarefa);
                //Retornando uma lista com a tarefa removida
                return lstResponse;
            }
            catch (Exception ex)
            {
                //Retornando erro "Caso dê erro"
                throw ex;
            }
        }
    }
}
