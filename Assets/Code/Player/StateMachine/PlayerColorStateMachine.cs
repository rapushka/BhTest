using System;
using System.Collections.Generic;
using Code.Player.StateMachine.ColorStates;
using Code.Player.StateMachine.DashStates;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerColorStateMachine : MonoBehaviour
	{
		[SerializeField] private ColorChangeComponent _colorChange;
		[SerializeField] private float _durationChangedColorState = 3;

		private Dictionary<Type, ColorState> _states;
		private ColorState _currentColorState;

		private void Start()
		{
			_states = new Dictionary<Type, ColorState>
			{
				[typeof(ColorDefaultState)] = new ColorDefaultState(_colorChange),
				[typeof(ColorChangedState)] = new ColorChangedState(_colorChange, _durationChangedColorState)
			};

			SwitchState<ColorDefaultState>();
		}

		public void Collide(DashState otherDashState)
		{
			_currentColorState.OnCollide(this, otherDashState);
		}

		public void SwitchState<T>()
		{
			_currentColorState = _states[typeof(T)];
			_currentColorState.Enter(this);
		}

		private void Update()
		{
			_currentColorState.OnUpdate(this);
		}
	}
}