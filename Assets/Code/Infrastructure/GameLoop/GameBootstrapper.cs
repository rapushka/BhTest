using Code.Infrastructure.GameStates;
using Code.Workflow;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameLoop
{
	public class GameBootstrapper : MonoBehaviour
	{
		[Scene] [SerializeField] private string _bootstrapScene;
		[SerializeField] private DerivedNetworkRoomManager _roomManagerPrefab;
		[SerializeField] private GameStateMachine _gameStateMachinePrefab;
		[SerializeField] private GameObject _uiRootPrefab;

		private DerivedNetworkRoomManager _roomManager;
		private GameStateMachine _gameStateMachine;

		private void Awake()
		{
			DontDestroyOnLoad(this);
			SceneManager.LoadScene(_bootstrapScene);

			GameObject uiInstance = Instantiate(_uiRootPrefab);
			DontDestroyOnLoad(uiInstance);
			_roomManager = CreateNetworkRoomManager();
			_gameStateMachine = CreateGameStateMachine(_roomManager);
		}

		private void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
		private void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
		{
			if (scene.name != Constants.SceneName.OfflineScene
			    || _roomManager)
			{
				return;
			}

			_roomManager = CreateNetworkRoomManager();
			_gameStateMachine.Construct(_roomManager);
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