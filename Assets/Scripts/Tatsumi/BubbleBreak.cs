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

	public void Break() {
		BreakEv.Invoke();
	}
}
