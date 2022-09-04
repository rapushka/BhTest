using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[SerializeField] private ColorChangeComponent _colorChangeComponent;
		
		private Dictionary<Type, IColorState> _states;
		private IColorState _currentColorState;

		private void Start()
		{
			_states = new Dictionary<Type, IColorState>
			{
				[typeof(ColorChangedState)] = new ColorChangedState(_colorChangeComponent),
			};

			_currentColorState = State<ColorChangedState>();
		}

		public void Collide()
		{
			State<ColorChangedState>().Enter(this);
		}

		public void SwitchState<T>()
		{
			_currentColorState = State<T>();
			_currentColorState.Enter(this);
		}

		private IColorState State<T>() => _states[typeof(T)];
	}
}