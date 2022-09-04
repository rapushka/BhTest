using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DefaultState : IPlayerState
	{
		public void Enter(PlayerStateMachine stateMachine)
		{
			// Change Color
		}

		public void OnUpdate(PlayerStateMachine stateMachine)
		{
			
		}

		public void OnCollide(PlayerStateMachine stateMachine, Collision collision)
		{
			if (collision.gameObject.TryGetComponent(out PlayerStateMachine collisionStateMachine)
			    && collisionStateMachine.CurrentState is DashingState)
			{
				stateMachine.SwitchState<ColorChangedState>();
			}
		}

		public void OnDash(PlayerStateMachine stateMachine)
		{
			stateMachine.SwitchState<DashingState>();
		}
	}
}