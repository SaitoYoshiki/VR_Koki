﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag=="Bubble"){
			Debug.Log("Ban!");
			//バブル破壊処理
		}
	}

}
