using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleZone : MonoBehaviour
{
    public GameObject puzzleObject;
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
        if (other.tag == "Player") {
            puzzleObject.GetComponent<Puzzle1>().inPuzzleZone = true;
            Debug.Log("entered puzzle zone");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        puzzleObject.GetComponent<Puzzle1>().inPuzzleZone = false;
    }
}
