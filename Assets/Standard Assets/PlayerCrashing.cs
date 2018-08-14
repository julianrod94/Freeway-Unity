using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrashing : MonoBehaviour
{

	private float timeCrashing = 1f;
	public float timeLeft;
		
	// Use this for initialization
	void Start ()
	{
		timeLeft = timeCrashing;
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeft > 0)
		{
			var bound = Camera.main.GetComponent<Camera>().orthographicSize * 0.85f;
			transform.Translate(0,-0.01f,0);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-bound,bound), transform.position.z);
		}
		else
		{
			gameObject.GetComponent<PlayerController>().canControl = true;
			Destroy(this);
		}

		timeLeft -= Time.deltaTime;
	}
}
