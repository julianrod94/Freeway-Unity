using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car")
        {
            var bound = Camera.main.GetComponent<Camera>().orthographicSize * 1.1f;
            transform.Translate(0,- other.gameObject.transform.localScale.y*2,0);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-bound, bound), transform.position.z);
        }
    }
}
