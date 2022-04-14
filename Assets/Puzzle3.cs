using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Puzzle3 : MonoBehaviour
{
    public int leftWeight = 0;
    public int rightWeight = 0;
    public GameManager gameManager;
    public GameObject finalHexagon;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (leftWeight == 20 && leftWeight == rightWeight) {
            door.GetComponent<Animator>().enabled = true;
            finalHexagon.GetComponent<XRGrabInteractable>().enabled = true;
        }
    }

    public void colourPuzzleComplete() {
        gameManager.puzzle3 = true;
    }
}
