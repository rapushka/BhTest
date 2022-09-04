using UnityEngine;

namespace Code.Player.StateMachine
{
	public class ColorChangedState : IColorState
	{
		private float _stateDuration;
		private float _beingTime;

		public void Enter(PlayerStateMachine stateMachine)
		{
			_stateDuration = stateMachine.ColorChangedStateDuration;
			Debug.Log("Change Color to Changed");
		}

		public void OnUpdate(PlayerStateMachine stateMachine)
		{
			_beingTime += Time.deltaTime;

			if (_beingTime >= _stateDuration)
			{
				stateMachine.SwitchColorState<DefaultColorState>();
			}
		}

		public void OnCollide(PlayerStateMachine stateMachine, Collider collider) { }
	}
}