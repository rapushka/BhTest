using Code.Player.Dash;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private DashComponent _dashComponent;
		[SerializeField] private float _colorChangedStateDuration;

		public float DashDuration => _dashComponent.DashDuration;
		public float ColorChangedStateDuration => _colorChangedStateDuration;
		public IPlayerState CurrentState { get; private set; }

		public void SwitchState<TState>()
			where TState : IPlayerState, new()
		{
			CurrentState = new TState();
			CurrentState.Enter(this);
		}

		private void Start()
		{
			SwitchState<DefaultState>();

			_input.Dashing += OnDashing;
		}

		private void OnDashing() => CurrentState.OnDash(this);

		private void Update() => CurrentState.OnUpdate(this);

		private void OnCollisionEnter(Collision collision) => CurrentState.OnCollide(this, collision);
	}
}