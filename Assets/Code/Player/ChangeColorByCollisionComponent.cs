using Code.Infrastructure;
using Code.Player.StateMachine;
using Code.Player.StateMachine.DashStates;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ChangeColorByCollisionComponent : NetworkBehaviour
	{
		[SerializeField] private CollisionLocator _collisionLocator;
		[SerializeField] private PlayerDashStateMachine _dashStateMachine;

		private void Start() => _collisionLocator.Collide += OnCollide;

		private void OnCollide(GameObject other)
		{
			var otherStateMachine = other.GetComponentInChildren<PlayerColorStateMachine>();
			otherStateMachine.Collide(_dashStateMachine.CurrentState);
		}
	}
}