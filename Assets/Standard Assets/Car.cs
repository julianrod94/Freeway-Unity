using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour {
	
	public float initialSpeed;
	private float currentSpeed;
	private int limit;
	
	public Direction direction;

	public enum Direction
	{
		LEFT,RIGHT
	}

	private Vector3 initialPosition;

	// Use this for initialization
	void Start ()
	{
		if (direction == Direction.LEFT)
		{
			initialSpeed = -initialSpeed;
		}
		currentSpeed = initialSpeed;

		
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var rand = new Random();

		if (Random.value < 0.01)
		{
			currentSpeed = initialSpeed * (0.8f + Random.value * 0.4f);
		}

		var sceenWidth = Screen.width;
		
		
		var x = Time.deltaTime * currentSpeed;
		
		
		var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;    
		var horzExtent = vertExtent * Screen.width / Screen.height;

		if (Math.Abs(transform.position.x) > Math.Abs(horzExtent*1.2))
		{
			transform.position = initialPosition;
		}
		transform.Translate(x, 0, 0);
	}
}
