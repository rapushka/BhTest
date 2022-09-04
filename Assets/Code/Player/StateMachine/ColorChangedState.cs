using UnityEngine;

namespace Code.Player.StateMachine
{
	public class ColorChangedState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;
		private readonly float _durationChangedColorState;
		private float _beingDuration;

		public ColorChangedState(ColorChangeComponent colorChangeComponent, float durationChangedColorState)
		{
			_colorChangeComponent = colorChangeComponent;
			_durationChangedColorState = durationChangedColorState;
		}

		public void Enter(PlayerStateMachine stateMachine)
		{
			_beingDuration = 0f;
			_colorChangeComponent.ToChangedColor();
		}

		public void OnUpdate(PlayerStateMachine stateMachine)
		{
			_beingDuration += Time.deltaTime;

			if (_beingDuration >= _durationChangedColorState)
			{
				stateMachine.SwitchState<ColorDefaultState>();
			}
		}

		public void OnCollide(PlayerStateMachine stateMachine) { }
	}
}