using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBound : MonoBehaviour {
	[SerializeField]
	Rigidbody rb = null;
	[SerializeField, Tooltip("被吹っ飛び倍率")]
	float boundRate = 1.0f;
	[SerializeField, Tooltip("打ち勝ち度")]
	float powerfulRate = 1.0f;

	[SerializeField]
	Enemy enemy = null;
	[SerializeField]
	float lastBoundTime = 0.0f;
	[SerializeField]
	float boundEnemyStopTime = 1.0f;

	private void FixedUpdate() {
		if (enemy && !enemy.enabled) {
			if (Time.time > (lastBoundTime + boundEnemyStopTime)) {
				enemy.enabled = true;
			}
		}
	}

	private void OnCollisionEnter(Collision _col) {
		Rigidbody colRb = _col.gameObject.GetComponent<Rigidbody>();
		if (!colRb) return;
		CollisionBound colBound = _col.gameObject.GetComponent<CollisionBound>();
		if (!colBound) return;

		Vector3 selfToColVec = (_col.transform.position - transform.position).normalized;

		float selfPower = Vector3.Dot(rb.velocity, selfToColVec);
		float colPower = Vector3.Dot(colRb.velocity, -selfToColVec);
		if ((selfPower * rb.mass * powerfulRate) < (colPower * colRb.mass * colBound.powerfulRate)) {
			Debug.Log("Hit Lose " + name + "\n" + (-selfToColVec * colPower * boundRate));
			rb.AddForce((-selfToColVec * colPower * boundRate), ForceMode.VelocityChange);
			lastBoundTime = Time.time;
			if (enemy) {
				enemy.enabled = false;
			}
		}
		else {
			Debug.Log("Hit Win " + name);
			rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
		}
	}
}
