using Mirror;
using UnityEngine;

namespace Code.Message
{
	public struct PositionMessage : NetworkMessage 
	{
		public Vector3 position; 
	}
}