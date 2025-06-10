using Command.Main;
namespace Command.Commands
{
    public class CleanseCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousPower;

        public CleanseCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute()
        {
            previousPower = targetUnit.CurrentPower;
            GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            if (willHitTarget)
                targetUnit.CurrentPower = previousPower;

            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}