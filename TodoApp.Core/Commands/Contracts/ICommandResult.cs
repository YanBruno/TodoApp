namespace TodoApp.Core.Commands.Contracts
{
    public interface ICommandResult{
        string Message{get;set;}
        bool Success {get;set;}
        object Data {get;set;}
    }
}