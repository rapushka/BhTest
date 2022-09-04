using Code.Infrastructure;
using Code.Player.Dash;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private DashComponent _dashComponent;
		[SerializeField] private float _colorChangedStateDuration;
		[SerializeField] private CollisionLocator _collisionLocator;
		[SerializeField] private MaterialChangeComponent _materialChangeComponent;

		public DashComponent DashComponent => _dashComponent;
		public float DashDuration => _dashComponent.DashDuration;
		public float ColorChangedStateDuration => _colorChangedStateDuration;
		public MaterialChangeComponent MaterialChangeComponent => _materialChangeComponent;

		public IDashingState CurrentDashingState { get; private set; }
		public IColorState CurrentColorState { get; private set; }

		public void SwitchDashingState<TState>()
			where TState : IDashingState, new()
			=> CurrentDashingState = SwitchState<TState>();

		public void SwitchColorState<TState>()
			where TState : IColorState, new()
			=> CurrentColorState = SwitchState<TState>();

		private void Start()
		{
			SwitchColorState<DefaultColorState>();
			SwitchDashingState<DefaultDashingState>();

			_input.Dashing += OnDashing;
			_collisionLocator.Collide += OnCollide;
		}

		private void Update()
		{
			CurrentDashingState.OnUpdate(this);
			CurrentColorState.OnUpdate(this);
		}

		private void OnDashing() => CurrentDashingState.OnDashInput(this);

		private void OnCollide(GameObject collision)
		{
			CurrentDashingState.OnCollide(this, collision);
			CurrentColorState.OnCollide(this, collision);
		}

		private TState SwitchState<TState>()
			where TState : IPlayerState, new()
		{
			var playerState = new TState();
			playerState.Enter(this);
			return playerState;
		}
	}
}