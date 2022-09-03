using Code.Messages;
using Code.Messages.Senders;
using Code.Messages.Subscribers;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkBootstrapper : NetworkManager
	{
		[Header("Messages")] 
		[SerializeField] private TransformSender _transformSender;
		[SerializeField] private TransformSubscriber _transformSubscriber;
		
		public override void OnStartServer()
		{
			base.OnStartServer();
			
			// Subscribers
			NetworkServer.RegisterHandler<TransformMessage>(_transformSubscriber.Register);
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();
			
			
			// Senders
			_transformSender.Send(NetworkClient.localPlayer.transform);
		}
	}
}