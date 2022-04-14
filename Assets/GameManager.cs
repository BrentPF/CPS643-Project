using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    public bool puzzle1 = false;
    public bool puzzle2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle1) {
            gate1.GetComponent<Gate>().open();
        }
        if (puzzle2)
        {
            gate2.GetComponent<Gate>().open();
        }
    }
}
