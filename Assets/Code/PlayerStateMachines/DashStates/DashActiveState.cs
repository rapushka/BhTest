using Code.CommonStateMachines;
using Code.Gameplay.Dash;
using Code.Gameplay.Score;
using Code.PlayerStateMachines.ColorStates;
using Code.Workflow.Extensions;

namespace Code.PlayerStateMachines.DashStates
{
	public class DashActiveState : TimeBouncedState<DashPassiveState>, IDashState
	{
		private readonly PlayerScore _playerScore;

		public DashActiveState(DashComponent dashComponent, PlayerScore playerScore)
			: base(dashComponent.DashDuration)
			=> _playerScore = playerScore;

		public void OnDash(PlayerDashStateMachine playerDashStateMachine) { }

		public void OnCollide(IColorState otherColorState)
			=> _playerScore.Do((s) => s.IncrementScore(), @if: otherColorState is ColorDefaultState);
	}
}