using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[FormerlySerializedAs("_colorChangeComponent")] [SerializeField] private ColorChangeComponent _colorChange;
		[SerializeField] private float _durationChangedColorState = 3;

		private Dictionary<Type, IColorState> _states;
		private IColorState _currentColorState;

		private void Start()
		{
			_states = new Dictionary<Type, IColorState>
			{
				[typeof(ColorChangedState)] = new ColorChangedState(_colorChange, _durationChangedColorState),
				[typeof(ColorDefaultState)] = new ColorDefaultState(_colorChange),
			};

			SwitchState<ColorDefaultState>();
		}

		public void Collide()
		{
			SwitchState<ColorChangedState>();
		}

		public void SwitchState<T>()
		{
			_currentColorState = State<T>();
			_currentColorState.Enter(this);
		}

		private void Update()
		{
			_currentColorState.OnUpdate(this);
		}

		private IColorState State<T>() => _states[typeof(T)];
	}
}