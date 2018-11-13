using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideGrabController : MonoBehaviour {
	[SerializeField, Tooltip("入力を受けるコントローラー")]
	SteamVR_TrackedObject trackedObj = null;

	[SerializeField, Tooltip("掴んでいるか")]
	bool isGrabbing = false;
	public bool IsGrabbing {
		get {
			return isGrabbing;
		}
		set {
			isGrabbing = value;
		}
	}

	[SerializeField, Tooltip("掴める距離であるかのチェックを行うオブジェクトのリスト")]
	List<InsideGrabbableObject> grabCheckObjList = new List<InsideGrabbableObject>();

	[SerializeField, Tooltip("掴んでいる対象オブジェクト")]
	InsideGrabbableObject grabObj = null;
	[SerializeField, Tooltip("掴んでいる方向")]
	Vector3 grabVec = Vector3.zero;

	[SerializeField, Tooltip("Inspectorから掴み状態を変更する")]
	bool inspectorGrab = false;
	bool prevInspectorGrab = false;

	[SerializeField, Tooltip("回転させるRigidbody")]
	Rigidbody grabRb = null;

	[SerializeField, Tooltip("掴んでいる位置に設定するオブジェクト")]
	Transform grabPoint = null;

	[SerializeField, Tooltip("回転感度")]
	float rotSence = 1.0f;

	void Update() {
		// Inspectorから掴み状態を変更する
		if (inspectorGrab != prevInspectorGrab) {
			if (inspectorGrab != IsGrabbing) {
				if (inspectorGrab) {
					Grab();
				} else {
					Release();
				}
				inspectorGrab = IsGrabbing;
			}
		}
		prevInspectorGrab = inspectorGrab;

		// コントローラーの入力を処理
		if (trackedObj.gameObject.activeInHierarchy) {
			SteamVR_Controller.Device ctrlDevice = SteamVR_Controller.Input((int)trackedObj.index);
			if (ctrlDevice.GetHairTriggerDown()) {
				Grab();
			}
			else if (ctrlDevice.GetHairTriggerUp()) {
				Release();
			}
		}

		// 掴んだまま動かす
		if (IsGrabbing) {
			// 現在の掴んでいる方向を取得
			Vector3 nowGrabVec = (transform.position - grabObj.transform.position).normalized; ;

			// 前回の掴んでいる方向からの差を取得
			Vector3 euler = (Quaternion.LookRotation(nowGrabVec) * Quaternion.Inverse(Quaternion.LookRotation(grabVec))).eulerAngles;
			grabVec = nowGrabVec;
			if (euler.x > 180.0f) {
				euler.x -= 360.0f;
			}
			if (euler.y > 180.0f) {
				euler.y -= 360.0f;
			}
			if (euler.z > 180.0f) {
				euler.z -= 360.0f;
			}

			// 掴んでいる位置にオブジェクトを移動
			if (grabPoint) {
				grabPoint.position = (grabObj.transform.position + (nowGrabVec * grabObj.Radius * 0.5f));
			}

			//// 回転
			grabRb.AddTorque((euler * rotSence), ForceMode.Force);
		}
	}

	public void Grab() {
		// 掴めるオブジェクトを探す
		foreach (var grabbableObj in grabCheckObjList) {
			float dis = Vector3.Distance(transform.position, grabbableObj.transform.position);
			if (Mathf.Abs(dis - grabbableObj.Radius) <= grabbableObj.CanGrabRangeDis) {
				// 掴む
				IsGrabbing = true;
				grabObj = grabbableObj;
				grabRb = grabObj.GetComponentInParent<Rigidbody>();

				// 掴んでいる方向を取得
				grabVec = (transform.position - grabObj.transform.position).normalized;

				return;
			}
		}
	}

	public void Release() {
		// 離す
		IsGrabbing = false;
		grabObj = null;
		grabVec = Vector3.zero;
		grabRb = null;
	}

	void OnTriggerEnter(Collider _col) {
		InsideGrabbableObject grabbableObj = _col.GetComponent<InsideGrabbableObject>();
		if (!grabbableObj) return;
		if (grabCheckObjList.Contains(grabbableObj)) return;
		grabCheckObjList.Add(grabbableObj);
	}
	void OnTriggerExit(Collider _col) {
		InsideGrabbableObject grabbableObj = _col.GetComponent<InsideGrabbableObject>();
		if (!grabbableObj) return;
		grabCheckObjList.Remove(grabbableObj);
	}
}
