using System;
using System.Collections.Generic;
using Code.Infrastructure;
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

		public ColorState CurrentColorState { get; private set; }

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
			CurrentColorState.OnCollide(this, otherDashState);
		}

		public void SwitchState<T>()
		{
			CurrentColorState = _states[typeof(T)];
			CurrentColorState.Enter(this);
		}

		private void Update()
		{
			CurrentColorState.OnUpdate(this);
		}
	}
}