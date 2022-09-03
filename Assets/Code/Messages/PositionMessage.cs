using Mirror;
using UnityEngine;

namespace Code.Messages
{
	public struct PositionMessage : NetworkMessage 
	{
		public Vector3 position; 
	}
}