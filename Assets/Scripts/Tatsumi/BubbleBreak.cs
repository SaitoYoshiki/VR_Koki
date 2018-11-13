using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBreak : MonoBehaviour {
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

	public void Break() {
		BreakEv.Invoke();
		if (breakParticle) {
			Instantiate(breakParticle, breakParent);
		}
	}
	public void DestroyBreak(Transform _target) {
		Destroy(_target.gameObject);
	}
	public void ZeroScalingBreak(Transform _target) {
		_target.localScale = Vector3.zero;
	}
}
