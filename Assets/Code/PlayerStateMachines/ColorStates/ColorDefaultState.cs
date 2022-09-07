using Code.CommonStateMachines;
using Code.Gameplay.Collisions;
using Code.PlayerStateMachines.DashStates;
using Code.Workflow.Extensions;

namespace Code.PlayerStateMachines.ColorStates
{
	public class ColorDefaultState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorDefaultState(ColorChangeComponent colorChangeComponent)
		{
			_colorChangeComponent = colorChangeComponent;
		}

		public void Enter(IStateMachine stateMachine) => _colorChangeComponent.ToDefaultColor();

		public void OnUpdate(IStateMachine stateMachine) { }
		public void Exit(IStateMachine stateMachine) { }

		public void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState) 
			=> colorStateMachine.Do(SwitchToChangedColor, @if: otherDashState is DashActiveState);

		private static void SwitchToChangedColor(PlayerColorStateMachine stateMachine) 
			=> stateMachine.SwitchState<ColorChangedState>();
	}
}