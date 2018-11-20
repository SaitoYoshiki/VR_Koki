using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBubble : MonoBehaviour {

	public float upScale;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag=="Player"){
			other.transform.parent.GetComponent<EventValue>().Val+=upScale;
		}
	}
}
