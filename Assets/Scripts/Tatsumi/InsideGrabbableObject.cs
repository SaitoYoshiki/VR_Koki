using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideGrabbableObject : MonoBehaviour {
	[SerializeField, Tooltip("掴める判定を行う球の半径")]
	float radius = 5.0f;
	public float Radius {
		get {
			return radius;
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
