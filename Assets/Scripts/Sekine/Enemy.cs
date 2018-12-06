using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public GameObject playerObj;

	[SerializeField]
	private GameObject modelObj;

	private Rigidbody rb;

	[SerializeField]
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

		Vector3 vec = playerObj.transform.position - modelObj.transform.position;
		modelObj.transform.rotation = Quaternion.LookRotation(vec);

		//回転させる
		rb.AddTorque(modelObj.transform.right* MoveSpeed);
	}

}
