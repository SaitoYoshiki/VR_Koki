using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateHead : MonoBehaviour {
	[SerializeField, Tooltip("対象")]
	Transform target = null;
	[SerializeField, Tooltip("デバッグカメラ")]
	Transform debubCam = null;
	[SerializeField, Tooltip("基準オブジェクト")]
	Transform baseObj = null;
	[SerializeField, Tooltip("回転速度")]
	float moveSpd = 10.0f;
	[SerializeField]
	KeyCode leftRotKey = KeyCode.Q, rightRotKey = KeyCode.E;

	void Update() {
		if (Input.GetKey(leftRotKey)) {
			target.rotation *= Quaternion.Euler(Vector3.down * moveSpd * Time.deltaTime);
			debubCam.RotateAround(baseObj.position, Vector3.down, (moveSpd * Time.deltaTime));
		}
		if (Input.GetKey(rightRotKey)) {
			target.rotation *= Quaternion.Euler(Vector3.up * moveSpd * Time.deltaTime);
			debubCam.RotateAround(baseObj.position, Vector3.up, (moveSpd * Time.deltaTime));
		}
	}
}
