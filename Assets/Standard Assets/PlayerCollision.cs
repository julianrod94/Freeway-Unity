using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Car")
        {
            transform.Translate(0,-2f,0);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,0f,8.5f), transform.position.z);
        }
    }
}
