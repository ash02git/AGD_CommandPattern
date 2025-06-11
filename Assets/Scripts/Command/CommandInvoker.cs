using Command.Main;
using System.Collections.Generic;
namespace Command.Commands
{
    public class CommandInvoker
    {
        // A stack to keep track of executed commands.
        private Stack<ICommand> commandRegistry = new Stack<ICommand>();

        public CommandInvoker() => SubscribeToEvents();

        private void SubscribeToEvents() => GameService.Instance.EventService.OnReplayButtonClicked.AddListener(SetReplayStack);

        public void SetReplayStack()
        {
            GameService.Instance.ReplayService.SetCommandStack(commandRegistry);
            commandRegistry.Clear();
        }

        public void ProcessCommand(ICommand commandToProcess)//Process a command, which involves both executing it and registering it.
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();// Execute a command, invoking its associated action.

        public void RegisterCommand(ICommand commandToRegister) => commandRegistry.Push(commandToRegister);// Register a command by adding it to the command registry stack.

        public void Undo()
        {
            if (!RegistryEmpty() && CommandBelongsToActivePlayer())
                commandRegistry.Pop().Undo();
        }

        private bool RegistryEmpty() => commandRegistry.Count == 0;

        private bool CommandBelongsToActivePlayer() => (commandRegistry.Peek() as UnitCommand).commandData.ActorPlayerID == GameService.Instance.PlayerService.ActivePlayerID;
    }
}
