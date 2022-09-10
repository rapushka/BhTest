using Code.Infrastructure.GameStates;
using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Infrastructure.GameLoop
{
	public class GameBootstrapper : MonoBehaviour
	{
		[SerializeField] private DerivedNetworkRoomManager _networkRoomManagerPrefab;
		[SerializeField] private GameStateMachine _gameStateMachinePrefab;

		private void Awake()
		{
			DontDestroyOnLoad(this);

			DerivedNetworkRoomManager networkRoomManager = CreateNetworkRoomManager();
			CreateGameStateMachine(networkRoomManager);
		}

		private DerivedNetworkRoomManager CreateNetworkRoomManager()
			=> Instantiate(_networkRoomManagerPrefab)
				.Do(DontDestroyOnLoad);

		private void CreateGameStateMachine(DerivedNetworkRoomManager networkRoomManager)
			=> Instantiate(_gameStateMachinePrefab)
			   .Do((sm) => sm.Construct(networkRoomManager))
			   .Do(DontDestroyOnLoad);
	}
}