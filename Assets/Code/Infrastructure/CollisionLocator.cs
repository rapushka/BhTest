using System;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class CollisionLocator : NetworkBehaviour
	{
		public event Action<GameObject> Collide;

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Collider otherCollider = hit.collider;
			if (otherCollider.TryGetComponent(out NetworkBehaviour _))
			{
				OnCollision(otherCollider.gameObject);
			}
		}

		private void OnCollision(GameObject other)
		{
			if (hasAuthority)
			{
				CmdSendCollision(other);
			}
			else
			{
				SendCollision(other);
			}
		}

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