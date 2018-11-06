using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScale : MonoBehaviour {
	[SerializeField, Tooltip("適用する値を持つコンポーネント")]
	EventValue bubbleSclVal = null;
	[SerializeField, Tooltip("大きさを変更するオブジェクト")]
	Transform target = null;

	public void Scaling() {
		target.localScale = (Vector3.one * bubbleSclVal.Val);
	}
}
