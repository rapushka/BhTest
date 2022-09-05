using System;
using Code.Player.Dash;
using Code.Player.StateMachine.ColorStates;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class DashActiveState : DashState
	{
		private readonly float _dashDuration;

		private float _beingTime;

		public event Action Hit;
		
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

		public override void OnCollide(ColorState otherColorState)
		{
			if (otherColorState is ColorDefaultState)
			{
				Hit?.Invoke();
			}
		}
	}
}