using System;
using Code.Player.Dash;
using Code.Player.Score;
using Code.Player.StateMachine.ColorStates;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class DashActiveState : DashState
	{
		private readonly float _dashDuration;
		private readonly PlayerScore _playerScore;

		private float _beingTime;
		
		public DashActiveState(DashComponent dashComponent, PlayerScore playerScore)
		{
			_playerScore = playerScore;
			_dashDuration = dashComponent.DashDuration;
		}

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
				_playerScore.IncrementScore();
			}
		}
	}
}