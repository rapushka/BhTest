using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ColorChangeComponent : NetworkBehaviour
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color _default;
		[SerializeField] private Color _changed;

		[SyncVar(hook = nameof(SyncColor))] private Color _syncColor;

		public void ToDefaultColor() => ChangeColor(_default);

		public void ToChangedColor() => ChangeColor(_changed);

		private void ChangeColor(Color color)
		{
			if (hasAuthority)
			{
				CmdApplyColor(color);
			}
			else
			{
				ApplyColor(color);
			}
		}

		[Command(requiresAuthority = false)] private void CmdApplyColor(Color color) => ApplyColor(color);

		[Server]
		private void ApplyColor(Color color)
		{
			_syncColor = color;
			RpcApplyColor(color);
		}

		[ClientRpc] private void RpcApplyColor(Color color) => _syncColor = color;

		private void SyncColor(Color _, Color newValue) => _renderer.material.color = _syncColor;
	}
}