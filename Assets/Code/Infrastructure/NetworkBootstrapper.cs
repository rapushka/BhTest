using Code.Message;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkBootstrapper : NetworkManager
	{
		[Header("Initialize Fields")]
		[SerializeField] private PositionSubscriber _positionSubscriber;

		[SerializeField] private Transform[] _spawnPoints;

		public override void OnStartServer()
		{
			base.OnStartServer();
			
			_positionSubscriber.Construct(playerPrefab);

			NetworkServer.RegisterHandler<PositionMessage>(_positionSubscriber.OnRegister);
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();

			SpawnPlayer();
		}
		
		private void SpawnPlayer()
		{
			var message = new PositionMessage
			{
				position = _spawnPoints.PickRandom().position
			};                  
			
			NetworkClient.connection.Send(message);
		}
	}
}