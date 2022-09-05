using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Infrastructure
{
	public class GameplayNetworkManager : NetworkManager
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q) == false)
			{
				return;
			}

			NetworkIdentity connection = NetworkClient.connection.identity;
			if (connection == false)
			{
				return;
			}

			connection
				.GetComponentInChildren<Text>()
				.text = "Text Changed from NetworkManager";
		}
	}
}