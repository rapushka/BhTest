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
			GameObject other = hit.collider.gameObject;
			if (other.TryGetComponent(out NetworkBehaviour _))
			{
				CmdOnCollision(other);
			}
		}

		[Command]
		private void CmdOnCollision(GameObject other)
		{
			RpcExplode(other);
		}

		[ClientRpc]
		private void RpcExplode(GameObject other)
		{
			Collide?.Invoke(other);
		}
	}
}