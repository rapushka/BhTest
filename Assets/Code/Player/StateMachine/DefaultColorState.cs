using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DefaultColorState : IColorState
	{
		public void Enter(PlayerStateMachine stateMachine)
		{
			stateMachine.MaterialChangeComponent.ToDefaultColor();
		}

		public void OnUpdate(PlayerStateMachine stateMachine) { }

		public void OnCollide(PlayerStateMachine stateMachine, Collider collider)
		{
			if (collider.GetDashingState() is DashingState)
			{
				stateMachine.SwitchColorState<ColorChangedState>();
			}
		}
	}
}