using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public GameObject playerObj;

	private Rigidbody rb;

	private float MoveSpeed = 10.0f;

	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
	}
	
	void Update ()
	{
		
	}

	void FixedUpdate()
	{
		Move();
	}

	public void Delete()
	{
		Destroy(this.gameObject);
	}

	void Move()
	{
		//プレイヤーの方向を向く
		Vector3 vec = playerObj.transform.position - this.transform.position;
		this.transform.rotation = Quaternion.LookRotation(vec);

		//回転させる
		rb.AddTorque(this.transform.right * MoveSpeed);
	}

}
