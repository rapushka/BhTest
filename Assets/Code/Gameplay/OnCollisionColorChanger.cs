using Code.Gameplay.Collisions;
using Code.Gameplay.PlayerStateMachines.ColorStates;
using Code.Gameplay.PlayerStateMachines.DashStates;
using Packages.Mirror.Runtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay
{
	public class OnCollisionColorChanger : NetworkBehaviour
	{
		[FormerlySerializedAs("_collisionLocator")] [SerializeField] private CollisionAdapter _collisionAdapter;
		[SerializeField] private PlayerDashStateMachine _dashStateMachine;
		
		private void Start() => _collisionAdapter.Collide += OnCollide;

		private void OnCollide(GameObject other)
		{
			var otherStateMachine = other.GetComponentInChildren<PlayerColorStateMachine>();
			if (otherStateMachine == null)
			{
				return;
			}

			_dashStateMachine.Collide(otherStateMachine.CurrentState);
			otherStateMachine.Collide(_dashStateMachine.CurrentState);
		}
	}
}