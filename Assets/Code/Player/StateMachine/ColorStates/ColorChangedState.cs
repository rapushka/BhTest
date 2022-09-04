using Code.Player.StateMachine.DashStates;
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

		public override void Enter(PlayerColorStateMachine colorStateMachine)
		{
			_beingDuration = 0f;
			ColorChangeComponent.ToChangedColor();
		}

		public override void OnUpdate(PlayerColorStateMachine colorStateMachine)
		{
			_beingDuration += Time.deltaTime;

			if (_beingDuration >= _durationChangedColorState)
			{
				colorStateMachine.SwitchState<ColorDefaultState>();
			}
		}

		public override void OnCollide(PlayerColorStateMachine colorStateMachine, DashState otherDashState) { }
	}
}