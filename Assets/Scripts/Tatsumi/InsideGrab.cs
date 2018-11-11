using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideGrab : MonoBehaviour {
	[SerializeField, Tooltip("掴むオブジェクト")]
	Transform grabTargetObj = null;
	[SerializeField, Tooltip("球形の半径")]
	float radius = 0.5f;
	[SerializeField, Tooltip("球の半径に占める掴める許容距離の割合")]
	float grabRatio = 0.5f;

	[SerializeField, Tooltip("掴んでいるコントローラー")]
	ControllerGrab grabCtrl = null;

	[SerializeField, Tooltip("掴んでくる可能性があるコントローラー")]
	List<ControllerGrab> grabCtrlList = new List<ControllerGrab>();
	[SerializeField, Tooltip("コントローラーが掴める状態にあるか")]
	List<bool> canGrabList = new List<bool>();

	[SerializeField, Tooltip("掴めるポイントを示すオブジェクトのプレハブ")]
	GameObject grabPointPrefab = null;
	[SerializeField, Tooltip("掴めるポイントを示すオブジェクト")]
	List<Transform> grabPointObjList = new List<Transform>();
	[SerializeField, Tooltip("掴めるコライダーのプレハブ")]
	GameObject canGrabColliderPrefab = null;
	[SerializeField, Tooltip("掴めるコライダー")]
	List<Transform> canGrabColliderList = new List<Transform>();

	void Start() {
		canGrabList.Clear();
		grabPointObjList.Clear();
		canGrabColliderList.Clear();
		for (int cnt = 0; cnt < grabCtrlList.Count; cnt++) {
			canGrabList.Add(false);
			grabPointObjList.Add(null);
			canGrabColliderList.Add(null);
		}
	}

	void Update() {
		// 対象となり得るコントローラーが掴める状態にあるかを更新
		for(int idx = 0; idx < grabCtrlList.Count; idx++) {
			// 中心からの距離を求める
			float dis = Vector3.Distance(grabTargetObj.position, grabCtrlList[idx].transform.position);

			// 中心からの距離から球状の縁からの距離を求める
			float edgeDis = (dis - radius);

			// 縁からの距離が許容範囲内かを設定
			bool prevCanGrab = canGrabList[idx];
			canGrabList[idx] = (edgeDis <= (radius * grabRatio));

			// 掴める状態が変更された場合
			if (prevCanGrab != canGrabList[idx]) {
				// 掴めるようになった場合
				if (canGrabList[idx]) {
					// 掴めるポイントを示すオブジェクトを生成
					grabPointObjList[idx] = Instantiate(grabPointPrefab, transform).transform;

					// 掴めるコライダーを生成
					canGrabColliderList[idx] = Instantiate(canGrabColliderPrefab, grabCtrlList[idx].transform).transform;
				}
				// 掴めないようになった場合
				else {
					// 掴めるポイントを示すオブジェクトを削除
					Destroy(grabPointObjList[idx].gameObject);
					grabPointObjList[idx] = null;

					// 掴めるコライダーを削除
					Destroy(canGrabColliderList[idx].gameObject);
					canGrabColliderList[idx] = null;
				}
			}
			
			// 掴める場合
			if (canGrabList[idx]) {
				// 掴めるポイントを示すオブジェクトの位置を設定
				grabPointObjList[idx].position = ((grabCtrlList[idx].transform.position - grabTargetObj.position).normalized * radius);
			}
		}
	}
}
