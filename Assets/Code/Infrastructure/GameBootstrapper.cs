using Code.Infrastructure.GameStates;
using UnityEngine;

namespace Code.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		[SerializeField] private GameStateMachine _gameStateMachinePrefab;
		
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}