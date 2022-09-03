using Code.Messages;
using Code.Messages.Senders;
using Code.Messages.Subscribers;
using Code.Player;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkBootstrapper : NetworkManager
	{
		[Header("Messages")]
		[SerializeField] private PositionSubscriber _positionSubscriber;
		[SerializeField] private PositionSender _positionSender;
		[SerializeField] private Follower _playerCameraFollower;

		public override void OnStartServer()
		{
			base.OnStartServer();
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();
			
			ConstructCamera();
		}

		private void ConstructCamera()
		{
			_playerCameraFollower.Construct(NetworkClient.localPlayer.transform);
		}
	}
}