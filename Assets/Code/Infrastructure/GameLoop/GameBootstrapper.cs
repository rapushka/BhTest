using Code.Infrastructure.GameStates;
using Code.UI;
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

		private GameStateMachine _gameStateMachine;
		private DerivedNetworkRoomManager _roomManager;
		private WinScreen _winScreen;

		private void Awake()
		{
			DontDestroyOnLoad(this);
			SceneManager.LoadScene(_bootstrapScene);

			GameObject uiRoot = Instantiate(_uiRootPrefab);
			DontDestroyOnLoad(uiRoot);
			_winScreen = uiRoot.GetComponent<WinScreen>();
			
			_roomManager = CreateNetworkRoomManager(_winScreen);
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

			_roomManager = CreateNetworkRoomManager(_winScreen);
			_gameStateMachine.Construct(_roomManager);
		}

		private DerivedNetworkRoomManager CreateNetworkRoomManager(WinScreen winScreen)
			=> Instantiate(_roomManagerPrefab)
			   .Do((nm) => nm.Construct(winScreen))
			   .Do(DontDestroyOnLoad);

		private GameStateMachine CreateGameStateMachine(DerivedNetworkRoomManager roomManager)
			=> Instantiate(_gameStateMachinePrefab)
			   .Do((sm) => sm.Construct(roomManager))
			   .Do(DontDestroyOnLoad);
	}
}