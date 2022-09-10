using Code.Infrastructure.GameStates;
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

			DerivedNetworkRoomManager networkRoomManager = Instantiate(_networkRoomManagerPrefab);
			DontDestroyOnLoad(networkRoomManager);

			GameStateMachine gameStateMachine = Instantiate(_gameStateMachinePrefab);
			gameStateMachine.Construct(networkRoomManager);
			DontDestroyOnLoad(gameStateMachine);
		}
	}
}