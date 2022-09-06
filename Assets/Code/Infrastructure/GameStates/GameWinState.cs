using System.Collections.Generic;
using Code.Infrastructure.StateMachines;
using Code.Player.Score;
using Code.Workflow;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameStates
{
	public class GameWinState : TimeBouncedState<GameplayState>, IGameState
	{
		private readonly IEnumerable<PlayerScore> _playerScores;

		public GameWinState(float duration, IEnumerable<PlayerScore> playerScores)
			: base(duration)
		{
			_playerScores = playerScores;
		}

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			Debug.Log("Game Win State Enter");
		}

		public override void Exit(IStateMachine stateMachine)
		{
			base.Exit(stateMachine);

			SceneManager.LoadScene(Constants.SceneName.OnlineScene);
		}
	}
}