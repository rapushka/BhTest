using System;
using Code.Workflow.Extensions;
using Packages.Mirror.Runtime;
using UnityEngine;

namespace Code.Gameplay.Collisions
{
	public class CollisionAdapter : NetworkBehaviour
	{
		public event Action<GameObject> Collide;

		private void OnControllerColliderHit(ControllerColliderHit hit)
			=> hit.collider.Do((c) => OnCollision(c.gameObject), @if: IsNetworkBehaviour);

		private static bool IsNetworkBehaviour(Collider c) 
			=> c.TryGetComponent(out NetworkBehaviour _);

		private void OnCollision(GameObject other)
			=> other.Do(@if: hasAuthority, @true: CmdSendCollision, @false: SendCollision);

		[Command(requiresAuthority = false)] private void CmdSendCollision(GameObject other) 
			=> SendCollision(other);

		[Server]
		private void SendCollision(GameObject other)
		{
			Collide?.Invoke(other);
			RpcSendCollision(other);
		}

		[ClientRpc] private void RpcSendCollision(GameObject other) => Collide?.Invoke(other);
	}
}