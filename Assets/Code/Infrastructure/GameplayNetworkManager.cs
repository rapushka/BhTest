using Mirror;

namespace Code.Infrastructure
{
	public class GameplayNetworkManager : NetworkManager
	{
		private int _counter = 1;
		

		public override void OnServerAddPlayer(NetworkConnectionToClient conn)
		{
			base.OnServerAddPlayer(conn);
		}
	}
}