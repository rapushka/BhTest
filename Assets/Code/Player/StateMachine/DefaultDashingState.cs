using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DefaultDashingState : IDashingState
	{
		public void Enter(PlayerStateMachine stateMachine) { }

		public void OnUpdate(PlayerStateMachine stateMachine) { }

		public void OnCollide(PlayerStateMachine stateMachine, GameObject collider) { }

		public void OnDashInput(PlayerStateMachine stateMachine)
		{
			stateMachine.DashComponent.Dash();
			stateMachine.SwitchDashingState<DashingState>();
		}
	}
}