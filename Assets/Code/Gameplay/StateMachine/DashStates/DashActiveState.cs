using Code.CommonStateMachines;
using Code.Gameplay.Dash;
using Code.Gameplay.Score;
using Code.Gameplay.StateMachine.ColorStates;

namespace Code.Gameplay.StateMachine.DashStates
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