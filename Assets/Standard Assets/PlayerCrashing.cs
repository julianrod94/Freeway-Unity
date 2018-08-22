using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrashing : MonoBehaviour
{

	private const float timeCrashing = 0.7f;
	private const float crashingSpeed = -0.08f;
	
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
			transform.Translate(0,crashingSpeed,0,Space.World);
			transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-bound,bound), transform.position.z);
			transform.Rotate(new Vector3(0,0,1), -15f);
		}
		else
		{
			gameObject.GetComponent<PlayerController>().canControl = true;
			transform.rotation = Quaternion.identity;
			Destroy(this);
		}
		
		timeLeft -= Time.deltaTime;
	}

	public void AddTime() {
		timeLeft = timeCrashing;
	}
}
