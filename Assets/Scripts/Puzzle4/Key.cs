using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string value;
    public Puzzle4 puzzle4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlight() {
        GetComponent<Outline>().enabled = !GetComponent<Outline>().enabled;
    }

    public void select() {
        Debug.Log("SELECTED");
        StartCoroutine(puzzle4.addCharacter(value));
    }
}
