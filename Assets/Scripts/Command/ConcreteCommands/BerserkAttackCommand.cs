using Command.Main;
namespace Command.Commands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;

        public BerserkAttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override void Undo()
        {
            if(willHitTarget)
            {
                if (!targetUnit.IsAlive())
                    targetUnit.Revive();

                targetUnit.RestoreHealth(actorUnit.CurrentPower * 2);
            }
            else
            {
                if (!actorUnit.IsAlive())
                    actorUnit.Revive();

                actorUnit.RestoreHealth(actorUnit.CurrentPower * 2);
            }
            actorUnit.Owner.ResetCurrentActiveUnit();
        }
    }
}