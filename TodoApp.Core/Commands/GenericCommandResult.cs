using TodoApp.Core.Commands.Contracts;

namespace TodoApp.Core.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {
        }

        public GenericCommandResult(string message, bool success, object data)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public string Message { get;set; }
        public bool Success { get;set; }
        public object Data { get;set; }
    }
}