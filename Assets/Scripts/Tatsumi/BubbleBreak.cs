using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBreak : MonoBehaviour {
	enum BubbleType {
		PlayerBubble,
		EnemyBubble,
		Other,
	}
	[SerializeField, Tooltip("泡の種類")]
	BubbleType type = BubbleType.Other;

	[SerializeField, Tooltip("破裂時に実行するイベント")]
	UnityEngine.Events.UnityEvent breakEv = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent BreakEv {
		get {
			return breakEv;
		}
	}

	[SerializeField, Tooltip("破裂時のパーティクルのプレハブ")]
	GameObject breakParticle = null;
	[SerializeField, Tooltip("破裂時のパーティクルの親")]
	Transform breakParent = null;

	GameState gameSt = null;
	GameState GameSt {
		get {
			if (!gameSt) {
				gameSt = FindObjectOfType<GameState>();
			}
			return gameSt;
		}
	}

	public void Break() {
		// 敵が全滅していればプレイヤーは死なない
		if (GameSt.IsGameClear && (type == BubbleType.PlayerBubble)) {
			return;
		}

		BreakEv.Invoke();
		if (breakParticle) {
			Instantiate(breakParticle, breakParent);
		}

		// 泡の種類による処理
		if (type != BubbleType.Other) {
			
		}
	}
	public void DestroyBreak(Transform _target) {
		Destroy(_target.gameObject);
	}
	public void ZeroScalingBreak(Transform _target) {
		_target.localScale = Vector3.zero;
	}
}
