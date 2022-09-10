using Code.CommonStateMachines;
using Code.Workflow;
using Code.Workflow.Extensions;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameStates
{
	public class GamePreparationState : IGameState
	{
		public void Enter(IStateMachine stateMachine) => SceneManager.LoadScene(Constants.SceneName.OfflineScene);

		public void OnUpdate(IStateMachine stateMachine) => stateMachine.Do(ToGameplayState, @if: IsOnlineScene);

		private void ToGameplayState(IStateMachine stateMachine) => stateMachine.SwitchState<GameplayState>();

		private static bool IsOnlineScene => SceneManager.GetActiveScene().name == Constants.SceneName.OnlineScene;

		public void Exit(IStateMachine stateMachine) { }

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}