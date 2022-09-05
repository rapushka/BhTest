using Code.Player.Score;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class NetworkRoomManagerExt : NetworkRoomManager
	{
		[Header("Start Game Button")] [SerializeField] private Vector2 _position;
		[SerializeField] private Vector2 _scale;

		private bool _showStartButton;

		public override bool OnRoomServerSceneLoadedForPlayer
			(NetworkConnectionToClient conn, GameObject roomPlayer, GameObject gamePlayer)
		{
			var playerScore = gamePlayer.GetComponent<PlayerScore>();
			int index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
			playerScore.Construct("Player", index);

			return true;
		}

		public override void OnRoomServerPlayersReady()
		{
#if UNITY_SERVER
            base.OnRoomServerPlayersReady();
#else
			_showStartButton = true;
#endif
		}

		public override void OnGUI()
		{
			base.OnGUI();

			if (allPlayersReady == false
			    || _showStartButton == false
			    || IsStartGameButtonPressed() == false)
			{
				return;
			}

			_showStartButton = false;
			ServerChangeScene(GameplayScene);
		}

		private static bool IsStartGameButtonPressed()
			=> GUI.Button
			(
				new Rect
				(
					x: 150,
					y: 300,
					width: 120,
					height: 20
				),
				"StartGame"
			);
	}
}