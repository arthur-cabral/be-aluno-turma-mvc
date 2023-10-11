namespace DesafioTecnicoAlunoTurma.Models
{
    public class MessageResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public MessageResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public MessageResponse(bool success)
        {
            Success = success;
        }
    }
}
