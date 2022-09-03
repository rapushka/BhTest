using Code.Message;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkBootstrapper : NetworkManager
	{
		[Header("Initialize Fields")]
		[SerializeField] private Transform[] _spawnPoints;

		public override void OnStartServer()
		{
			base.OnStartServer();
			
			NetworkServer.RegisterHandler<PositionMessage>(OnCreateCharacter);
		}

		public override void OnClientConnect()
		{
			base.OnClientConnect();

			SpawnPlayer();
		}
		
		private void OnCreateCharacter(NetworkConnectionToClient connection, PositionMessage message)
		{
			GameObject player = Instantiate(playerPrefab, message.position, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(connection, player);
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