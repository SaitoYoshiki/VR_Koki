using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMass : MonoBehaviour {
	[SerializeField, Tooltip("適用する値を持つコンポーネント")]
	EventValue bubbleMassVal = null;
	[SerializeField, Tooltip("質量を変更するオブジェクト")]
	Rigidbody target = null;
	[SerializeField, Tooltip("基準質量")]
	float baseVal = 0.0f;
	[SerializeField, Tooltip("値によって変化する質量")]
	float changeMass = 100.0f;

	void Start() {
		SettingMass();
	}

	public void SettingMass() {
		target.mass = (baseVal + (bubbleMassVal.Val * changeMass));
	}
}
