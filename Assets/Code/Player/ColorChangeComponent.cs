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
			if (isServer)
			{
				ApplyColor(color);
			}
			else if (hasAuthority)
			{
				CmdApplyColor(color);
			}
		}

		[Command] private void CmdApplyColor(Color color) => ApplyColor(color);

		[Server] private void ApplyColor(Color color) => _syncColor = color;

		private void SyncColor(Color oldValue, Color newValue) => _renderer.material.color = newValue;
	}
}