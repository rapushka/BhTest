using System;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Gameplay.Collisions
{
	public class CollisionAdapter : NetworkBehaviour
	{
		public event Action<GameObject> Collide;

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Collider otherCollider = hit.collider;
			
			otherCollider.Do((c) => OnCollision(c.gameObject), @if: IsNetworkBehaviour);
			bool IsNetworkBehaviour(Collider c) => c.TryGetComponent(out NetworkBehaviour _);
		}

		private void OnCollision(GameObject other) 
			=> other.Do(@if: hasAuthority, @true: CmdSendCollision, @false: SendCollision);

		[Command(requiresAuthority = false)] private void CmdSendCollision(GameObject other) => SendCollision(other);

		[Server]
		private void SendCollision(GameObject other)
		{
			Collide?.Invoke(other);
			RpcSendCollision(other);
		}

		[ClientRpc] private void RpcSendCollision(GameObject other) => Collide?.Invoke(other);
	}
}