using Code.Player.Score;
using Code.UI;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure
{
	public class DerivedNetworkRoomManager : NetworkRoomManager
	{
		[Scene] [SerializeField] private string _winScene;
		[SerializeField] private WinScreen _winScreen;

		[Header("Start Game Button")] [SerializeField] private Vector2 _position;
		[SerializeField] private Vector2 _scale;

		private bool _showStartButton;

		public override bool OnRoomServerSceneLoadedForPlayer
			(NetworkConnectionToClient conn, GameObject roomPlayer, GameObject gamePlayer)
		{
			var playerScore = gamePlayer.GetComponent<PlayerScore>();
			int index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
			var playerName = $"Player{index + 1}";
			playerScore.Construct(playerName, index);

			return true;
		}

		public void GameOver(string winnerName)
		{
			ServerChangeScene(_winScene);

			_winScreen.DisplayWinnerName(winnerName);
		}

		public void PlayAgain()
		{
			ServerChangeScene(onlineScene);
			_winScreen.Hide();
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

		private bool IsStartGameButtonPressed()
			=> GUI.Button
			(
				new Rect
				(
					x: _position.x,
					y: _position.y,
					width: _scale.x,
					height: _scale.y
				),
				"Start Game"
			);
	}
}