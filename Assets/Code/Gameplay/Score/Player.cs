using System;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Score
{
	public class Player : NetworkBehaviour
	{
		[SerializeField] private Text _playerNameView;
		[Header("GUI Layout")] [SerializeField] private Vector2 _position;
		[SerializeField] private Vector2 _scale;
		[SerializeField] private float _spaceBetween;

		[SyncVar(hook = nameof(SyncScore))] private int _syncScoreValue;
		[SyncVar(hook = nameof(SyncPlayerName))] private string _syncPlayerName;
		[SyncVar] private int _index;

		private int _scoreValue;

		public event Action<string, int> ScoreIncrease;

		public void Construct(string playerName, int index) => (_syncPlayerName, _index) = (playerName, index);

		public void Destroy()
			=> SynchronizeAction(serverSideAction: DestroySelf, clientSideAction: CmdDestroy);

		public void IncrementScore() 
			=> SynchronizeAction(serverSideAction: ApplyScore, clientSideAction: CmdApplyScore);

		private void SynchronizeAction(Action serverSideAction, Action clientSideAction)
			=> this.Do(@if: isServer, @true: (_) => serverSideAction(), @false: (_) => clientSideAction());

		private void OnGUI()
			=> GUI.Box
			(
				new Rect
				(
					x: _position.x + (_scale.x + _spaceBetween) * _index,
					y: _position.y,
					width: _scale.x,
					height: _scale.y
				),
				$"{_syncPlayerName}: {_scoreValue}"
			);

		[Command] private void CmdDestroy() => DestroySelf();

		[Server]
		private void DestroySelf()
		{
			NetworkServer.Destroy(gameObject);
			RpcDestroySelf();
		}

		[ClientRpc] private void RpcDestroySelf() => NetworkServer.Destroy(gameObject);

		[Command(requiresAuthority = false)] private void CmdApplyScore() => ApplyScore();

		[Server]
		private void ApplyScore()
		{
			_syncScoreValue++;
			RpcScoreIncrease(_syncScoreValue);
		}

		[ClientRpc] private void RpcScoreIncrease(int score) => ScoreIncrease?.Invoke(_syncPlayerName, score);

		// ReSharper disable UnusedParameter.Local
		private void SyncPlayerName(string _, string newValue) => _playerNameView.text = _syncPlayerName;
		private void SyncScore(int _, int newValue) => _scoreValue = _syncScoreValue;
		// ReSharper restore UnusedParameter.Local
	}
}