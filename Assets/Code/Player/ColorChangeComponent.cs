using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ColorChangeComponent : NetworkBehaviour
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color _default;
		[SerializeField] private Color _changed;

		[SyncVar(hook = nameof(SyncColor))] private Color _color;

		public void ToDefaultColor()
		{
			ChangeColor(_default);
		}

		public void ToChangedColor()
		{
			ChangeColor(_changed);
		}

		private void ChangeColor(Color color)
		{
			if (isServer)
			{
				ApplyColorOnServer(color);
			}
			else
			{
				CmdApplyColor(color);
			}
		}

		[Command] private void CmdApplyColor(Color material) => ApplyColorOnServer(material);

		[Server] private void ApplyColorOnServer(Color color) => _color = color;

		private void SyncColor(Color oldValue, Color newValue) => _renderer.material.color = newValue;
	}
}