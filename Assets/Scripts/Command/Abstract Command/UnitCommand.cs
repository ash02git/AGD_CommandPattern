using Command.Player;

namespace Command.Commands
{
    public abstract class UnitCommand : ICommand
    {
        // Fields to store information related to the command.
        public CommandData commandData;

        // References to the actor and target units, accessible by subclasses.
        protected UnitController actorUnit;
        protected UnitController targetUnit;

        public abstract void Execute(); //Abstract method to execute the unit command.Must be implemented by concrete subclasses.
        public abstract void Undo();//Abstract method to undo the unit command. Must be implemented by concrete subclasses.

        public abstract bool WillHitTarget();//Abstract method to determine whether the command will successfully hit its target.

        public void SetActorUnit(UnitController actorUnit) => this.actorUnit = actorUnit;

        public void SetTargetUnit(UnitController targetUnit) => this.targetUnit = targetUnit;
    }
}