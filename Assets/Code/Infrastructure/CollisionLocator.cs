using System;
using UnityEngine;

namespace Code.Infrastructure
{
	public class CollisionLocator : MonoBehaviour
	{
		public event Action<Collider> Collide;

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			Collide?.Invoke(hit.collider);
		}
	}
}