using UnityEngine;

namespace Code.Player
{
	public class Follower : MonoBehaviour
	{
		public void Construct(Transform target)
		{
			transform.SetParent(target, worldPositionStays: false);
		}
	}
}