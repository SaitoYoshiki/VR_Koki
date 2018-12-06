using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBound : MonoBehaviour {
	[SerializeField]
	Rigidbody rb = null;
	[SerializeField, Tooltip("倍率")]
	float rate = 1.0f;

	private void OnCollisionEnter(Collision _col) {
		Rigidbody colRb = _col.gameObject.GetComponent<Rigidbody>();
		if (!colRb) return;

		Vector3 selfToColVec = (_col.transform.position - transform.position).normalized;

		float selfPower = Vector3.Dot(rb.velocity, selfToColVec);
		float colPower = Vector3.Dot(colRb.velocity, -selfToColVec);
		if ((selfPower * rb.mass) < (colPower * colRb.mass)) {
			Debug.Log("Hit Lose " + name);
			rb.AddForce((-selfToColVec * colPower * rate), ForceMode.VelocityChange);
		}
		else {
			Debug.Log("Hit Win " + name);
			rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
		}
	}
}
