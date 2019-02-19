using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
	[SerializeField, Tooltip("ゲームクリア状態か")]
	bool isGameClear = false;
	public bool IsGameClear {
		get {
			return isGameClear;
		}
		set {
			isGameClear = value;
		}
	}
	[SerializeField, Tooltip("ゲームオーバー状態か")]
	bool isGameOver = false;
	public bool IsGameOver {
		get {
			return isGameOver;
		}
		set {
			isGameOver = value;
		}
	}

	[SerializeField, Tooltip("敵の数"), ReadOnly]
	int enemyCnt = 0;

	void Start() {
		enemyCnt = FindObjectsOfType<Enemy>().Length;
	}
	public void PlayerBubbleBreak() {
		IsGameOver = true;
	}
	public void EnemyBubbleBreak() {
		enemyCnt--;

		// 敵が全滅したら
		IsGameClear = true;
	}
}
