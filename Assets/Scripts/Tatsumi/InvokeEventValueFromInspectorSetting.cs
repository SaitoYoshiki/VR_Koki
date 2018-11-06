using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeEventValueFromInspectorSetting : MonoBehaviour {
	[SerializeField, Tooltip("対象")]
	EventValue target = null;
	[SerializeField, Tooltip("前回更新時の値")]
	float prevVal = 0.0f;

	void Start() {
		prevVal = target.Val;
	}

	void Update() {
		if (prevVal != target.Val) {
			prevVal = target.Val;
			target.ChangeEv.Invoke();
			target.SetEv.Invoke();
		}
	}
}
