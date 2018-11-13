using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingObject : MonoBehaviour {
	[SerializeField, Tooltip("握られているオブジェクト")]
	ControllerGrab grabCtrl = null;
	public ControllerGrab GrabCtrl {
		get {
			return grabCtrl;
		}
		set {
			grabCtrl = value;
		}
	}

	[SerializeField, Tooltip("握られた時のイベント")]
	UnityEngine.Events.UnityEvent grabEv = new UnityEngine.Events.UnityEvent();

	[SerializeField, Tooltip("離された時のイベント")]
	UnityEngine.Events.UnityEvent releaseEv = new UnityEngine.Events.UnityEvent();
}
