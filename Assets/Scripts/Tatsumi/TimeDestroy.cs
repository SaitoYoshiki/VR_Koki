using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {
	[SerializeField, Tooltip("消滅までの所要時間")]
	float destroyTime = 10.0f;
	[SerializeField, Tooltip("残り時間")]
	float remainTime = 0.0f;
	[SerializeField, Tooltip("対象")]
	Transform target = null;

	void Start() {
		remainTime = destroyTime;
	}

	void FixedUpdate() {
		remainTime -= Time.fixedDeltaTime;
		if (remainTime <= 0.0f) {
			Destroy(target.gameObject);
		}
	}
}
