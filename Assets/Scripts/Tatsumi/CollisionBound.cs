using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBound : MonoBehaviour {
	[SerializeField]
	Rigidbody rb = null;
	[SerializeField, Tooltip("被吹っ飛び倍率")]
	float selfBoundRate = 1.0f;
	[SerializeField, Tooltip("与吹っ飛び倍率")]
	float colBoundRate = 1.0f;
	[SerializeField, Tooltip("打ち勝ち度")]
	float powerfulRate = 1.0f;
	[SerializeField, Tooltip("衝突時のパーティクルのプレハブ")]
	GameObject particlePrefab = null;

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

		CollisionBound colBound = _col.gameObject.GetComponent<CollisionBound>();
		if (!colBound) return;

		if (!rb) return;

		Vector3 selfToColVec = (_col.transform.position - transform.position).normalized;

		bool forcible = false;
		float colPower = 0.0f;
		if (!colRb) {
			forcible = true;
		} else {
			float selfPower = Vector3.Dot(rb.velocity, selfToColVec);
			colPower = Vector3.Dot(colRb.velocity, -selfToColVec);
			forcible = (selfPower * rb.mass * powerfulRate) < (colPower * colRb.mass * colBound.powerfulRate);
		}

		SelectionBase colBase = _col.collider.GetComponentInParent<SelectionBase>();
		string colName = "";
		if (colBase) {
			colName = colBase.name;
		} else {
			colName = _col.collider.name;
		}

		if (forcible) {
			Debug.Log("Hit Lose " + name + " Win " + colName + "\n" + (-selfToColVec * colPower * selfBoundRate * colBound.colBoundRate));
			rb.AddForce((-selfToColVec * colPower * selfBoundRate * colBound.colBoundRate), ForceMode.Impulse);
			lastBoundTime = Time.time;
			if (enemy) {
				enemy.enabled = false;
			}
		}
		else {
			Debug.Log("Hit Win " + name + " Lose " + colName);
			rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
		}

		// 衝突位置にパーティクルを発生させる
		if (particlePrefab) {
			Transform particle = Instantiate(particlePrefab).transform;
			particle.position = _col.contacts[0].point;
			particle.LookAt(transform);
		}
	}
}
