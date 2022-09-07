using UnityEngine;

namespace Code.Infrastructure.GameLoop
{
	public class GameLoader : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper _gameBootstrapperPrefab;
		
		private void Awake() => CorrectBootstrapFromAnyScene();

		private void CorrectBootstrapFromAnyScene()
		{
			if (FindObjectOfType<GameBootstrapper>() == null)
			{
				Instantiate(_gameBootstrapperPrefab);
			}
		}
	}
}