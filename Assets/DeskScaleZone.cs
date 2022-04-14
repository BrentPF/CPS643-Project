using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeskScaleZone : MonoBehaviour
{
    public TextMeshPro puzzleText;
    public DeskScaleZone otherColourPillar;
    public bool rightColour = false;
    public bool isLeftPuzzleScale = false;
    public bool isRightPuzzleScale = false;
    public bool isColourScale = false;
    private int weight = 0;
    public Puzzle3 puzzle3;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLeftPuzzleScale && !isRightPuzzleScale && !isColourScale) {
            puzzleText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weight")
        {
            if (!isLeftPuzzleScale && !isRightPuzzleScale && !isColourScale)
            {
                weight += other.GetComponent<Weight>().weight;
                puzzleText.text = weight.ToString();
            }
            else if (isLeftPuzzleScale)
            {
                puzzle3.leftWeight += other.GetComponent<Weight>().weight;
            }
            else if (isRightPuzzleScale)
            {
                puzzle3.rightWeight += other.GetComponent<Weight>().weight;
            }
            else if (isColourScale) {
                if (other.GetComponent<Weight>().weight == 3) {
                    rightColour = true;
                    if (otherColourPillar.GetComponent<DeskScaleZone>().rightColour) {
                        puzzle3.colourPuzzleComplete();
                    }
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Weight")
        {
            if (!isLeftPuzzleScale && !isRightPuzzleScale)
            {
                weight -= other.GetComponent<Weight>().weight;
                if (weight != 0)
                {
                    puzzleText.text = weight.ToString();
                }
                else
                {
                    puzzleText.text = "";
                }
            }
            else if (isLeftPuzzleScale)
            {
                puzzle3.leftWeight -= other.GetComponent<Weight>().weight;
            }
            else if (isRightPuzzleScale)
            {
                puzzle3.rightWeight -= other.GetComponent<Weight>().weight;
            }
        }
    }
}
