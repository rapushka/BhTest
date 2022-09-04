using UnityEngine;

namespace Code.Player.StateMachine
{
	public class ColorChangedState : IPlayerState
	{
		private float _stateDuration;
		private float _beingTime;

		public void Enter(PlayerStateMachine stateMachine)
		{
			_stateDuration = stateMachine.ColorChangedStateDuration;
			// Change Color
		}

		public void OnUpdate(PlayerStateMachine stateMachine)
		{
			_beingTime += Time.deltaTime;

			if (_beingTime >= _stateDuration)
			{
				stateMachine.SwitchState<DefaultState>();
			}
		}

		public void OnCollide(PlayerStateMachine stateMachine, Collision collision)
		{
		}

		public void OnDash(PlayerStateMachine stateMachine)
		{
		}
	}
}