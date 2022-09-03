using Mirror;
using UnityEngine;

namespace Code.Messages.Subscribers
{
	public class PositionSubscriber : MonoBehaviour
	{
		private GameObject _playerPrefab;

		public void Construct(GameObject playerPrefab)
		{
			_playerPrefab = playerPrefab;
		}

		public void OnStartServer(NetworkConnectionToClient connection, PositionMessage message)
		{
			GameObject player = Instantiate(_playerPrefab, message.position, Quaternion.identity);
			NetworkServer.AddPlayerForConnection(connection, player);
		}
	}
}