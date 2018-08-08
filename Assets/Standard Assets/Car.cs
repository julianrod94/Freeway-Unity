using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
	
	public int speed;

	private Vector3 initialPosition;

	// Use this for initialization
	void Start ()
	{
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var x = Time.deltaTime * speed;
		if (transform.position.x + x < -11)
		{
			return;
		} 
		if (transform.position.x + x > 11)
		{
			transform.position = initialPosition;
		}
		transform.Translate(x, 0, 0);
	}
}
