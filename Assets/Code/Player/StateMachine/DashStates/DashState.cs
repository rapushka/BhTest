namespace Code.Player.StateMachine.DashStates
{
	public abstract class DashState
	{
		public abstract void Enter(PlayerDashStateMachine playerDashStateMachine);
		public abstract void OnDash(PlayerDashStateMachine playerDashStateMachine);
	}
}