using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallZone : MonoBehaviour
{
    public string ballTag;
    public ParticleSystem[] ballPs;
    public bool connected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ballTag)
        {
            foreach (ParticleSystem ps in ballPs) {
                ps.Play();
                connected = true;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ballTag)
        {
            foreach (ParticleSystem ps in ballPs)
            {
                ps.Stop();
                connected = false;
            }
        }
    }
}
