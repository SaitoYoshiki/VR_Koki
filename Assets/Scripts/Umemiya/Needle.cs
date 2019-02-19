using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

//	void OnTriggerEnter(Collider other){
//		if(other.gameObject.tag=="Player"){
//			other.transform.parent.GetComponent<BubbleBreak>().Break();
//		}
//	}
	void OnCollisionEnter(Collision other) {
//		if (other.gameObject.tag == "Player") {
			//			other.transform.parent.GetComponent<BubbleBreak>().Break();
			other.transform.GetComponentInParent<SelectionBase>().GetComponentInChildren<BubbleBreak>().Break();
//		}
	}

}
