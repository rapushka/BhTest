using UnityEngine;

namespace Code.Player.StateMachine.ColorStates
{
	public class ColorChangedState : ColorState
	{
		private readonly float _durationChangedColorState;
		private float _beingDuration;

		public ColorChangedState(ColorChangeComponent colorChangeComponent, float durationChangedColorState)
			: base(colorChangeComponent)
		{
			_durationChangedColorState = durationChangedColorState;
		}

		public override void Enter(PlayerStateMachine stateMachine)
		{
			_beingDuration = 0f;
			ColorChangeComponent.ToChangedColor();
		}

		public override void OnUpdate(PlayerStateMachine stateMachine)
		{
			_beingDuration += Time.deltaTime;

			if (_beingDuration >= _durationChangedColorState)
			{
				stateMachine.SwitchState<ColorDefaultState>();
			}
		}

		public override void OnCollide(PlayerStateMachine stateMachine) { }
	}
}