using Code.CommonStateMachines;
using Code.Gameplay.Collisions;
using Code.PlayerStateMachines.DashStates;

namespace Code.PlayerStateMachines.ColorStates
{
	public class ColorChangedState : TimeBouncedState<ColorDefaultState>, IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorChangedState(ColorChangeComponent colorChangeComponent, float durationChangedColorState)
			: base(durationChangedColorState)
			=> _colorChangeComponent = colorChangeComponent;

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			_colorChangeComponent.ToChangedColor();
		}

		public void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState) { }
	}
}