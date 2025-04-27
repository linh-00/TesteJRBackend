namespace Api.ToDo.Repository.DTOs
{
    public record TaskDTO
    {
        public int ID_TAREFA { get; init; }
        public string DS_TAREFA { get; set; }
    }
}
