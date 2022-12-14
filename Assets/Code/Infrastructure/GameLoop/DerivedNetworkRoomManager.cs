using Code.Gameplay.Score;
using Code.UI;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Infrastructure.GameLoop
{
	public class DerivedNetworkRoomManager : NetworkRoomManager
	{
		[SerializeField] private Rect _startGameButtonRect;

		private WinScreen _winScreen;
		private bool _showStartButton;
		private Player _player;

		public void Construct(WinScreen winScreen) => _winScreen = winScreen;
		
		public override bool OnRoomServerSceneLoadedForPlayer
			(NetworkConnectionToClient conn, GameObject roomPlayer, GameObject gamePlayer)
		{
			_player = gamePlayer.GetComponent<Player>();
			int index = roomPlayer.GetComponent<NetworkRoomPlayer>().index;
			var playerName = $"Player{index + 1}";
			
			_player.Construct(playerName, index);
			
			Destroy(roomPlayer);

			return true;
		}

		public void GameOver(string winnerName) => _winScreen.DisplayWinnerName(winnerName);

		public void PlayAgain()
		{
			_player.Do((p) => p.Destroy(), @if: (p) => p);
			
			ServerChangeScene(RoomScene);
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

		private bool IsStartGameButtonPressed() => GUI.Button(_startGameButtonRect, "Start Game");
	}
}