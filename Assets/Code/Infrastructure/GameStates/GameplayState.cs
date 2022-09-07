using Code.CommonStateMachines;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
	public class GameplayState : IGameState
	{
		private readonly int _scoreToWin;

		public GameplayState(int scoreToWin) => _scoreToWin = scoreToWin;

		public void Enter(IStateMachine stateMachine) { }

		public void OnUpdate(IStateMachine stateMachine) { }

		public void Exit(IStateMachine stateMachine) { }

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score)
		{
			Debug.Log($"{playerName} scored {score}!");

			if (score >= _scoreToWin)
			{
				stateMachine.SwitchState<GameWinState>();
			}
		}
	}
}