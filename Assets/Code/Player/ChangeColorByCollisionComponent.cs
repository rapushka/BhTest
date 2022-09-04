using Code.Infrastructure;
using Code.Player.StateMachine;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ChangeColorByCollisionComponent : NetworkBehaviour
	{
		[SerializeField] private CollisionLocator _collisionLocator;

		private void Start() => _collisionLocator.Collide += OnCollide;

		private void OnCollide(GameObject other)
		{
			var otherStateMachine = other.GetComponentInChildren<PlayerColorStateMachine>();
			otherStateMachine.Collide();
		}
	}
}