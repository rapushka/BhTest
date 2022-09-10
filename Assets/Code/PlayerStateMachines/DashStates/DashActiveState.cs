using Code.CommonStateMachines;
using Code.Gameplay.Dash;
using Code.Gameplay.Score;
using Code.PlayerStateMachines.ColorStates;
using Code.Workflow.Extensions;

namespace Code.PlayerStateMachines.DashStates
{
	public class DashActiveState : TimeBouncedState<DashPassiveState>, IDashState
	{
		private readonly Player _player;

		public DashActiveState(DashComponent dashComponent, Player player)
			: base(dashComponent.DashDuration)
			=> _player = player;

		public void OnDash(PlayerDashStateMachine playerDashStateMachine) { }

		public void OnCollide(IColorState otherColorState)
			=> _player.Do((s) => s.IncrementScore(), @if: otherColorState is ColorDefaultState);
	}
}