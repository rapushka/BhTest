using Code.Infrastructure.GameStates;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Gameplay.Score
{
	public class ScoreIncreaseAdapter : NetworkBehaviour
	{
		[FormerlySerializedAs("_playerScore")] [SerializeField] private Player _player;

		private GameStateMachine _gameStateMachine;

		private GameStateMachine GameStateMachine 
			=> _gameStateMachine ??= FindObjectOfType<GameStateMachine>();

		private void Start() => _player.ScoreIncrease += OnIncrease;

		private void OnDestroy() => _player.ScoreIncrease -= OnIncrease;

		private void OnIncrease(string playerName, int score) 
			=> GameStateMachine.OnScoreIncrease(playerName, score);
	}
}