using Code.Infrastructure.GameStateMachine;
using Code.Player.Dash;
using Code.Player.StateMachine.ColorStates;

namespace Code.Player.StateMachine.DashStates
{
	public class DashPassiveState : IDashState
	{
		private readonly DashComponent _dashComponent;

		public DashPassiveState(DashComponent dashComponent) => _dashComponent = dashComponent;

		public void OnDash(PlayerDashStateMachine playerDashStateMachine)
		{
			playerDashStateMachine.SwitchState<DashActiveState>();
			_dashComponent.Dash();
		}

		public void Enter(IStateMachine<IState> stateMachine) { }
		public void OnUpdate(IStateMachine<IState> stateMachine) { }
		public void OnCollide(IColorState otherColorState) { }
	}
}