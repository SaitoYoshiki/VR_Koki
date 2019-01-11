using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchEnemy : MonoBehaviour {

    // 敵を見つけた時、イベントを返す
    public event System.Action<GameObject> Found = (obj) => { };
    // 敵を見失ったときイベントを返す
    public event System.Action<GameObject> Lost = (obj) => { };

    void OnTriggerEnter(Collider other)
    {
        Found(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        Lost(other.gameObject);
    }
}
