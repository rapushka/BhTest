using Code.Infrastructure.GameStates;
using Code.Workflow;
using Code.Workflow.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Code.Infrastructure.GameLoop
{
	public class GameBootstrapper : MonoBehaviour
	{
		[SerializeField] private DerivedNetworkRoomManager _roomManagerPrefab;
		[SerializeField] private GameStateMachine _gameStateMachinePrefab;
		
		private DerivedNetworkRoomManager _roomManager;
		private GameStateMachine _gameStateMachine;

		private void Awake()
		{
			DontDestroyOnLoad(this);
			SceneManager.LoadScene(Constants.SceneName.OfflineScene);
			
			_roomManager = CreateNetworkRoomManager();

			_gameStateMachine = CreateGameStateMachine(_roomManager);
		}

		private void OnRoomManagerDestroyed()
		{
			_roomManager.Destroyed -= OnRoomManagerDestroyed;
			
			_roomManager = CreateNetworkRoomManager();
			_gameStateMachine.Construct(_roomManager);
			
			_roomManager.Destroyed += OnRoomManagerDestroyed;
		}

		private DerivedNetworkRoomManager CreateNetworkRoomManager()
			=> Instantiate(_roomManagerPrefab)
				.Do(DontDestroyOnLoad);

		private GameStateMachine CreateGameStateMachine(DerivedNetworkRoomManager roomManager)
			=> Instantiate(_gameStateMachinePrefab)
			   .Do((sm) => sm.Construct(roomManager))
			   .Do(DontDestroyOnLoad);
	}
}