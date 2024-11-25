namespace Parking_Lot.Trello
{
    public class CommandManager
    {
        private Stack<ICommand> commandHistory = new Stack<ICommand>();
        private Stack<ICommand> redoStack = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
            redoStack.Clear(); // Clear redo stack on a new command
        }

        public void Undo()
        {
            if (commandHistory.Count > 0)
            {
                var command = commandHistory.Pop();
                command.Undo();
                redoStack.Push(command);
            }
            else
            {
                Console.WriteLine("No commands to undo.");
            }
        }

        public void Redo()
        {
            if (redoStack.Count > 0)
            {
                var command = redoStack.Pop();
                command.Execute();
                commandHistory.Push(command);
            }
            else
            {
                Console.WriteLine("No commands to redo.");
            }
        }
    }

}
