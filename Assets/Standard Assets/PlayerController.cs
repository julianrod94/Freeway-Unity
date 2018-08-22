using System;
using System.Security.Policy;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public int player;
    private Vector3 initialPosition;

    public bool canControl = true;
    private String axis;

    // Use this for initialization
    void Start()
    {
        if (player == 1)
        {
            axis = "P1_Vertical";
        }
        else
        {
            axis = "P2_Vertical";
        }

        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl){
            var y = Input.GetAxis(axis) * Time.deltaTime * speed;
            var bound = Camera.main.GetComponent<Camera>().orthographicSize * 0.85f;
            transform.Translate(0, y, 0);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,-bound,bound), transform.position.z);
        }

    }

    public void ResetPosition() {
        transform.position = initialPosition;
    }

    public void CrashWithCar() {
        gameObject.GetComponent<PlayerController>().canControl = false;

        var playerCrashing = gameObject.GetComponent<PlayerCrashing>();
        if (playerCrashing == null) {
            gameObject.AddComponent<PlayerCrashing>();
        }
        else {
            playerCrashing.AddTime();
        }
    }
}