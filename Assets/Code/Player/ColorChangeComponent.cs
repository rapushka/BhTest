using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ColorChangeComponent : NetworkBehaviour
	{
		[SerializeField] private MeshRenderer _renderer;
		[SerializeField] private Color32 _default;
		[SerializeField] private Color32 _changed;

		[SyncVar(hook = nameof(SyncColor))] private Color32 _color;

		public void ToDefaultColor() => ChangeColor(_default);

		public void ToChangedColor() => ChangeColor(_changed);
		
		private void ChangeColor(Color32 color)
		{
			if (isServer)
			{
				ApplyColor(color);
			}
			else
			{
				CmdApplyColor(color);
			}
		}

		[Command(requiresAuthority = false)] private void CmdApplyColor(Color32 color) => ApplyColor(color);
		[Server] private void ApplyColor(Color32 color)
		{
			_color = color;
			RpcApplyColor(_color);
		}

		[ClientRpc] private void RpcApplyColor(Color32 color) => _renderer.material.color = color;
		
		private void SyncColor(Color32 _, Color32 newValue) => _renderer.material.color = newValue;
	}
}