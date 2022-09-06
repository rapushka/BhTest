using Code.Infrastructure.GameStateMachine;
using Code.Player.Dash;
using Code.Player.Score;
using Code.Player.StateMachine.ColorStates;

namespace Code.Player.StateMachine.DashStates
{
	public class DashActiveState : TimeBouncedState<DashPassiveState>, IDashState
	{
		private readonly PlayerScore _playerScore;

		public DashActiveState(DashComponent dashComponent, PlayerScore playerScore)
			: base(dashComponent.DashDuration)
		{
			_playerScore = playerScore;
		}

		public void OnDash(PlayerDashStateMachine playerDashStateMachine) { }

		public void OnCollide(IColorState otherColorState)
		{
			if (otherColorState is ColorDefaultState)
			{
				_playerScore.IncrementScore();
			}
		}
	}
}