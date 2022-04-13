using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float defaultPositionY;
    private ConstantForce defaultForce;

    public bool pressed = false;

    // Add constant up force

    // Start is called before the first frame update
    void Start()
    {
        defaultPositionY = gameObject.transform.position.y;
        defaultForce = gameObject.GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < defaultPositionY)
        {
            pressed = true;
        }
        else
        {
            pressed = false;
            defaultForce.enabled = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, defaultPositionY, gameObject.transform.position.z);
        }
    }
}