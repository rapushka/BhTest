using Code.Message;
using Code.Messages.Senders;
using Code.Messages.Subscribers;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkBootstrapper : NetworkManager
	{
		[Header("Initialize Fields")]
		[SerializeField] private PositionSubscriber _positionSubscriber;
		[SerializeField] private PositionSender _positionSender;
		
		public override void OnStartServer()
		{
			base.OnStartServer();
			
			_positionSubscriber.Construct(playerPrefab);

			NetworkServer.RegisterHandler<PositionMessage>(_positionSubscriber.OnRegister);
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();

			_positionSender.OnClientConnect();
		}
	}
}