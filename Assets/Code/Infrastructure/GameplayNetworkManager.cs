using Code.Player.Score;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class GameplayNetworkManager : NetworkManager
	{

		public override void OnClientConnect()
		{
			base.OnClientConnect();

			// NetworkIdentity identity = NetworkClient.connection.identity;
			//
			// if (identity == false)
			// {
			// 	return;
			// }
			//
			// int index = identity.GetComponent<NetworkRoomPlayer>().index;
			//
			// identity
			// 	.GetComponent<PlayerScore>()
			// 	.Construct($"Player{index}", index);
		}
	}
}