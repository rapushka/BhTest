using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class MaterialChangeComponent : NetworkBehaviour
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color _default;
		[SerializeField] private Color _changed;

		[SyncVar(hook = nameof(SyncColor))] private Color _color;
		
		[Command]
		private void CmdApplyColor(Color material)
		{
			ApplyColorOnServer(material);
		}
		
		[Server]
		private void ApplyColorOnServer(Color color)
		{
			_color = color;
		}

		private void Update()
		{
			if (hasAuthority == false)
			{
				return;
			}

			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				ChangeColor(_changed);
			}
			if (Input.GetKeyDown(KeyCode.Mouse2))
			{
				CmdApplyColor(_default);
			}
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

		private void SyncColor(Color oldValue, Color newValue) => _renderer.material.color = newValue;
	}
}