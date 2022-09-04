using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DashingState : IPlayerState
	{
		private float _dashDuration;
		private float _beingTime;

		public void Enter(PlayerStateMachine stateMachine)
		{
			_dashDuration = stateMachine.DashDuration;
		}

		public void OnUpdate(PlayerStateMachine stateMachine)
		{
			_beingTime += Time.deltaTime;

			if (_beingTime >= _dashDuration)
			{
				stateMachine.SwitchState<DefaultState>();
			}
		}

		public void OnCollide(PlayerStateMachine stateMachine, Collision collision)
		{
			if (collision.gameObject.TryGetComponent(out PlayerStateMachine collisionStateMachine)
			    && collisionStateMachine.CurrentState is DefaultState)
			{
				// score++
			}
		}

		public void OnDash(PlayerStateMachine stateMachine)
		{
		}
	}
}