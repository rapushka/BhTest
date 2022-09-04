using UnityEngine;

namespace Code.Player.StateMachine
{
	public class DefaultColorState : IColorState
	{
		public void Enter(PlayerStateMachine stateMachine)
		{
		}

		public void OnUpdate(PlayerStateMachine stateMachine) { }

		public void OnCollide(PlayerStateMachine stateMachine, Collider collider)
		{
			Debug.Log(collider.GetDashingState()?.ToString() ?? "NULL");
			if (collider.GetDashingState() is DashingState)
			{
				stateMachine.SwitchColorState<ColorChangedState>();
			}
		}
	}
}