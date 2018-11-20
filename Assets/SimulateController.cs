using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateController : MonoBehaviour {
	[SerializeField, Tooltip("移動速度")]
	float moveSpd = 1.0f;
	[SerializeField, Tooltip("回転速度")]
	float rotSpd = 10.0f;

	[SerializeField, Tooltip("対象")]
	InsideGrabController target = null;
	[SerializeField, Tooltip("基準オブジェクト")]
	Transform baseObj = null;
	[SerializeField, Tooltip("方向基準")]
	Transform forwardVecObj = null;
	[SerializeField, Tooltip("大きさの値")]
	EventValue scl = null;

	[SerializeField]
	KeyCode upKey = KeyCode.W, downKey = KeyCode.S, leftKey = KeyCode.A, rightKey = KeyCode.D;
	[SerializeField]
	KeyCode grabSwitchKey = KeyCode.LeftShift;
	[SerializeField]
	bool isGrab = false;

	private void Update() {
		if (Input.GetKeyDown(grabSwitchKey)) {
			isGrab = !isGrab;
			if (isGrab) {
				target.Grab();
			} else {
				target.Release();
			}
		}

		Quaternion rotForward = Quaternion.Euler(0.0f, forwardVecObj.rotation.eulerAngles.y, 0.0f);

		if (!isGrab) {
			Vector3 pos = baseObj.position;
			Vector3 vec = Vector3.zero;
			if (Input.GetKey(upKey)) {
				vec += (rotForward * Vector3.forward);
			}
			if (Input.GetKey(downKey)) {
				vec += (rotForward * Vector3.back);
			}
			if (Input.GetKey(leftKey)) {
				vec += (rotForward * Vector3.left);
			}
			if (Input.GetKey(rightKey)) {
				vec += (rotForward * Vector3.right);
			}
			vec.Normalize();

			pos += (vec * (scl.Val * 0.5f));
			target.transform.position = pos;
		} else {
			if (Input.GetKey(upKey)) {
				target.transform.RotateAround(baseObj.position, (rotForward * Vector3.right), moveSpd);
			}
			if (Input.GetKey(downKey)) {
				target.transform.RotateAround(baseObj.position, (rotForward * Vector3.left), moveSpd);
			}
			if (Input.GetKey(leftKey)) {
				target.transform.RotateAround(baseObj.position, (rotForward * Vector3.forward), moveSpd);
			}
			if (Input.GetKey(rightKey)) {
				target.transform.RotateAround(baseObj.position, (rotForward * Vector3.back), moveSpd);
			}
		}
	}
}
