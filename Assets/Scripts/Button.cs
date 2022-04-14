using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private float defaultPositionY;
    private ConstantForce defaultForce;
    public bool flipped = false;
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
        if ((!flipped && gameObject.transform.position.y < defaultPositionY) || (flipped == true && gameObject.transform.position.y > defaultPositionY))
        {
            Debug.Log("GO Y: " + gameObject.transform.position.y + ", Default Y: " + defaultPositionY);
            pressed = true;
            defaultForce.enabled = true;
        }
        else
        {
            pressed = false;
            defaultForce.enabled = false;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, defaultPositionY, gameObject.transform.position.z);
        }
    }
}