using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObjectChild : MonoBehaviour {
	[SerializeField, Tooltip("有効であれば親とするオブジェクト")]
	SteamVR_TrackedObject trackedObj = null;

	void Update() {
		if (trackedObj.gameObject.activeInHierarchy) {
			transform.parent = trackedObj.transform;
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
		}
//		enabled = false;
	}
}
