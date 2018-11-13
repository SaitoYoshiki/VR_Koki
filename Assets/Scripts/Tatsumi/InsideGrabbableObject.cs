using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideGrabbableObject : MonoBehaviour {
	[SerializeField, Tooltip("掴める判定を行う球の直径")]
	EventValue diameter = null;
	public EventValue Diameter {
		get {
			return diameter;
		}
	}
	[SerializeField, Tooltip("掴める判定を行う半径からの許容距離\n内側と外側にそれぞれ許容範囲が広がる")]
	float canGrabRangeDis = 0.5f;
	public float CanGrabRangeDis {
		get {
			return canGrabRangeDis;
		}
	}
}
