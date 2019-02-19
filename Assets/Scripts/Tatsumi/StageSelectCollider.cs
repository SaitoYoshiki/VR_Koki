using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectCollider : MonoBehaviour {
	static StageSelectCollider nowSelectCol = null;

	[SerializeField, Tooltip("遷移先のシーン名")]
	string sceneName = "";
	[SerializeField, Tooltip("対象オブジェクトのタグ名")]
	string targetTag = "Player";

	CircleFade fade = null;
	CircleFade Fade {
		get {
			if (!fade) {
				fade = FindObjectOfType<CircleFade>();
			}
			return fade;
		}
	}

	void OnCollisionEnter(Collision _col) {
		if (_col.collider.tag != targetTag) {
			return;
		}

		if (nowSelectCol) {
			return;
		}
		nowSelectCol = this;

		StartCoroutine(SelectSceneCoroutine());
	}

	IEnumerator SelectSceneCoroutine() {
		Fade.ChangeFadeState = CircleFade.FadeState.SetOut;
		while (true) {
			if (Fade.ChangeFadeState == CircleFade.FadeState.Complete) {
				break;
			}
			yield return null;
		}

		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

		nowSelectCol = null;
	}
}
