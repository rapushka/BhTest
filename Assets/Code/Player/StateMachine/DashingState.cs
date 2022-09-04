using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DashingState : IDashingState
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
				stateMachine.SwitchDashingState<DefaultDashingState>();
			}
		}

		public void OnCollide(PlayerStateMachine stateMachine, Collider collider)
		{
			if (collider.GetColorState() is DefaultColorState)
			{
				Debug.Log("Score++");
			}
		}

		public void OnDashInput(PlayerStateMachine stateMachine)
		{
		}
	}
}