using System.Collections.Generic;
namespace Command.Commands
{
    public class CommandInvoker
    {
        // A stack to keep track of executed commands.
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();


        public void ProcessCommand(ICommand commandToProcess)//Process a command, which involves both executing it and registering it.
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();// Execute a command, invoking its associated action.

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);// Register a command by adding it to the command registry stack.
    }
}
