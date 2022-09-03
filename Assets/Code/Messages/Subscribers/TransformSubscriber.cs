using Code.Player;
using Mirror;
using UnityEngine;

namespace Code.Messages.Subscribers
{
	public class TransformSubscriber : MonoBehaviour
	{
		[SerializeField] private Follower _playerCameraFollower;

		public void Register(NetworkConnectionToClient connection, TransformMessage message)
		{
		}
	}
}