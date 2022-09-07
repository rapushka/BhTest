using Code.CommonStateMachines;
using Code.Gameplay.Dash;
using Code.PlayerStateMachines.ColorStates;

namespace Code.PlayerStateMachines.DashStates
{
	public class DashPassiveState : IDashState
	{
		private readonly DashComponent _dashComponent;

		public DashPassiveState(DashComponent dashComponent) => _dashComponent = dashComponent;

		public void Enter(IStateMachine stateMachine) { }
		public void OnUpdate(IStateMachine stateMachine) { }
		public void Exit(IStateMachine stateMachine) { }

		public void OnDash(PlayerDashStateMachine playerDashStateMachine)
		{
			playerDashStateMachine.SwitchState<DashActiveState>();
			_dashComponent.Dash();
		}

		public void OnCollide(IColorState otherColorState) { }
	}
}