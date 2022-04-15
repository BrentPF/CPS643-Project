using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    public GameObject gate4;
    public bool puzzle1 = false;
    public bool puzzle2 = false;
    public bool puzzle3 = false;
    public bool puzzle4 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle1) {
            gate1.GetComponent<Gate>().open();
            puzzle1 = false;
        }
        if (puzzle2)
        {
            gate2.GetComponent<Gate>().open();
            puzzle2 = false;
        }
        if (puzzle3)
        {
            gate3.GetComponent<Gate>().open();
            puzzle3 = false;
        }
        if (puzzle4)
        {
            gate4.GetComponent<Gate>().open();
            puzzle4 = false;
        }
    }

}
