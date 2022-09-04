using Code.Player.Dash;

namespace Code.Player.StateMachine.DashStates
{
	public class DashPassiveState : DashState
	{
		private readonly DashComponent _dashComponent;

		public DashPassiveState(DashComponent dashComponent) => _dashComponent = dashComponent;

		public override void Enter(PlayerDashStateMachine playerDashStateMachine) { }

		public override void OnDash(PlayerDashStateMachine playerDashStateMachine)
		{
			playerDashStateMachine.SwitchState<DashActiveState>();
			_dashComponent.Dash();
		}

		public override void OnUpdate(PlayerDashStateMachine playerDashStateMachine) { }
	}
}