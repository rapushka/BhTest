using Code.Player.Dash;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class DashActiveState : DashState
	{
		private readonly float _dashDuration;

		private float _beingTime;

		public DashActiveState(DashComponent dashComponent) => _dashDuration = dashComponent.DashDuration;

		public override void Enter(PlayerDashStateMachine playerDashStateMachine)
		{
			_beingTime = 0f;
		}

		public override void OnDash(PlayerDashStateMachine playerDashStateMachine) { }

		public override void OnUpdate(PlayerDashStateMachine playerDashStateMachine)
		{
			_beingTime += Time.deltaTime;

			if (_beingTime >= _dashDuration)
			{
				playerDashStateMachine.SwitchState<DashPassiveState>();
			}
		}
	}
}