using UnityEngine;

namespace Code.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private void Awake()
		{
			DontDestroyOnLoad(this);
		}
	}
}