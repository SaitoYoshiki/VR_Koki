using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRelativeTarget : MonoBehaviour {
	[SerializeField, Tooltip("移動させる位置を示すオブジェクト")]
	Transform pointObj = null;
	[SerializeField, Tooltip("相対的に移動させて位置を合わせる子オブジェクト")]
	Transform relativeObj = null;

	void Update() {
		//		// 必要な移動量を取得
		//		Vector3 move = (pointObj.position - relativeObj.position);
		//
		//		// 自身を移動させる
		//		transform.position += move;
		float posY = transform.position.y;
		Vector3 pos = (pointObj.position - (relativeObj.position - transform.position));
		pos.y = posY;
		transform.position = pos;
	}
}
