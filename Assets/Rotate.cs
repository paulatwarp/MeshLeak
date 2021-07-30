using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float speed = 60.0f;
	void Update()
	{
		Vector3 euler = transform.rotation.eulerAngles;
		euler.y += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		transform.rotation = Quaternion.Euler(euler);
	}
}
