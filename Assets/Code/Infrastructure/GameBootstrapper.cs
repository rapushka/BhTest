using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);

			SceneManager.LoadScene("OfflineScene");
		}
	}
}