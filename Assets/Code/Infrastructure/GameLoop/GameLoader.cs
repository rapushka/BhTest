using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Infrastructure.GameLoop
{
	public class GameLoader : MonoBehaviour
	{
		[SerializeField] private GameBootstrapper _gameBootstrapperPrefab;

		private static bool BootstrapperWasNotCreated => FindObjectOfType<GameBootstrapper>() == null;
		
		private void Awake() => CorrectBootstrapFromAnyScene();

		private void CorrectBootstrapFromAnyScene() 
			=> _gameBootstrapperPrefab.Do(InstantiatePrefab, @if: BootstrapperWasNotCreated);

		private static void InstantiatePrefab(MonoBehaviour prefab) => Instantiate(prefab);
	}
}