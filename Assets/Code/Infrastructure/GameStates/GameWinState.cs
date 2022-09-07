using Code.Infrastructure.StateMachines;
using Code.Workflow;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameStates
{
	public class GameWinState : TimeBouncedState<GameplayState>, IGameState
	{
		private string _winnerName;

		public GameWinState(float duration)
			: base(duration) { }

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			_winnerName = ((GameStateMachine)stateMachine).LastSavedPlayerName;

			Debug.Log($"{_winnerName} is winner!");
			SceneManager.LoadScene(Constants.SceneName.WinScene);
		}

		public override void Exit(IStateMachine stateMachine)
		{
			base.Exit(stateMachine);

			Debug.Log("Game Win State Exit");
			var gameStateMachine = (GameStateMachine)stateMachine;
			gameStateMachine.NetworkRoomManager.Reset();
			gameStateMachine.NetworkRoomManager.allPlayersReady = true;
			SceneManager.LoadScene(Constants.SceneName.RoomScene);

			// _networkRoomManagerExt.RestartGame();
		}

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}