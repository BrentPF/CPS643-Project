using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject exitLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open() { 
        gameObject.GetComponent<Animator>().Play("Gate");
        gameObject.GetComponent<AudioSource>().enabled = true;
        exitLight.GetComponent<Light>().color = Color.green;
    }
}
