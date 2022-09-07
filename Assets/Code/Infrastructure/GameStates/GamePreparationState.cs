using Code.CommonStateMachines;
using Code.Workflow;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameStates
{
	public class GamePreparationState : IGameState
	{
		public void Enter(IStateMachine stateMachine) => SceneManager.LoadScene(Constants.SceneName.OfflineScene);

		public void OnUpdate(IStateMachine stateMachine)
		{
			string activeScene = SceneManager.GetActiveScene().name;
			if (activeScene == Constants.SceneName.OnlineScene)
			{
				stateMachine.SwitchState<GameplayState>();
			}
		}

		public void Exit(IStateMachine stateMachine) { }

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}