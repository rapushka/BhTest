using UnityEngine;

namespace Code.Infrastructure.GameLoop
{
	public class GameBootstrapper : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}