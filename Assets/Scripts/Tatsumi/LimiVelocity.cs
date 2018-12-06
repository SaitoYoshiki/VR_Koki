using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiVelocity : MonoBehaviour {
	[SerializeField]
	Rigidbody rb = null;
	[SerializeField]
	float limit = 1.0f;
	[SerializeField, ReadOnly]
	float prevVel = 0.0f;

	void Update() {
		if (rb.velocity.magnitude > limit) {
			rb.velocity = (rb.velocity.normalized * limit);
		}
		prevVel = rb.velocity.magnitude;
	}
}
