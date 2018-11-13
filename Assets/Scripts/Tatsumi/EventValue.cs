using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventValue : MonoBehaviour {
	[SerializeField, Tooltip("値")]
	float val = 1.0f;
	public float Val {
		get {
			return val;
		}
		set {
			float prevVal = val;
			val = Mathf.Clamp(value, min, max);
			// 値に変化があった時
			if (val != prevVal) {
				ChangeEv.Invoke();
			}
			SetEv.Invoke();
		}
	}
	[SerializeField, Tooltip("限界値")]
	float min = float.NegativeInfinity, max = float.PositiveInfinity;

	[Header("Valが設定された時に実行されるイベント。"), Header("ChangeEvは値が変化した際に呼び出される。"), Header("SetEvは値に変化が無くても呼び出される。"), Header("実行順はChangeEvが実行されてからSetEvが実行される。"),
		SerializeField, Tooltip("値が変更された時に設定後に実行されるイベント\n値に変化があった時のみ実行される\nChangeEvが実行された後にSetEvが実行される")]
	UnityEngine.Events.UnityEvent changeEv = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent ChangeEv {
		get {
			return changeEv;
		}
	}

	[SerializeField, Tooltip("値が設定された時に設定後に実行されるイベント\n値に変化がなくても実行される\nChangeEvが実行された後にSetEvが実行される")]
	UnityEngine.Events.UnityEvent setEv = new UnityEngine.Events.UnityEvent();
	public UnityEngine.Events.UnityEvent SetEv {
		get {
			return setEv;
		}
	}
}
