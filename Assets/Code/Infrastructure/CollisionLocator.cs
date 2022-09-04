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
			CmdOnCollision(hit.collider.gameObject);
		}

		[Command]
		private void CmdOnCollision(GameObject hit)
		{
			RpcExplode(hit);
		}

		[ClientRpc]
		private void RpcExplode(GameObject hit)
		{
			Collide?.Invoke(hit);
		}
	}
}