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

		
		initialPosition = new Vector3(horizontalBorder()*Math.Sign(initialSpeed)*-1, transform.position.y, 0);
		transform.position = initialPosition;
	}
	
	// Update is called once per frame
	void Update() {		
		var x = Time.deltaTime * currentSpeed;
		transform.Translate(x, 0, 0);

		if (Random.value < 0.01) {
			currentSpeed = initialSpeed * (0.8f + Random.value * 0.4f);
		}

		var border = horizontalBorder();

		if (direction == Direction.RIGHT && transform.position.x > border) {
			transform.position = initialPosition;
		}
		else if (direction == Direction.LEFT && transform.position.x < -border) {
			transform.position = initialPosition;
		}
	}

	private float horizontalBorder() {
		var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;
		return horzExtent * 1.2f;
	}
}
