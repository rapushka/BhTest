using Code.PlayerStateMachines.ColorStates;
using Code.PlayerStateMachines.DashStates;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Gameplay.Collisions
{
	public class OnCollisionColorChanger : NetworkBehaviour
	{
		[SerializeField] private CollisionAdapter _collisionAdapter;
		[SerializeField] private PlayerDashStateMachine _dashStateMachine;

		private void Start() => _collisionAdapter.Collide += OnCollide;

		private void OnCollide(GameObject other)
			=> other.GetComponentInChildren<PlayerColorStateMachine>()
			        .Do(InvokeCollide, @if: (sm) => sm);

		private void InvokeCollide(PlayerColorStateMachine otherStateMachine)
		{
			_dashStateMachine.Collide(otherStateMachine.CurrentState);
			otherStateMachine.Collide(_dashStateMachine.CurrentState);
		}
	}
}