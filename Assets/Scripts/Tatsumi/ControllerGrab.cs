using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrab : MonoBehaviour {
	[SerializeField, Tooltip("コントローラー")]
	SteamVR_TrackedObject trackedObj = null;

	[SerializeField, Tooltip("握っているか")]
	bool isGrab = false;
	public bool IsGrab {
		get {
			return isGrab;
		}
		private set {
			isGrab = value;
		}
	}

	[SerializeField, Tooltip("Inspectorから握るアクションを行う")]
	bool inspectorGrab = false;

	void Updaet() {
		if (inspectorGrab != IsGrab) {
			IsGrab = inspectorGrab;
		}
	}

	[SerializeField, Tooltip("握る対象となるオブジェクト"), ReadOnly]
	GrabbingObject grabObj = null;
	public GrabbingObject GrabObj {
		get {
			return grabObj;
		}
		set {
			grabObj = value;
		}
	}
}
