using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeEventValue : MonoBehaviour {
	[SerializeField, Tooltip("対象")]
	EventValue target = null;
	[SerializeField, Tooltip("変化量")]
	float timeVal = 0.0f;

	void FixedUpdate() {
		target.Val += (timeVal * Time.fixedDeltaTime);
	}
}
