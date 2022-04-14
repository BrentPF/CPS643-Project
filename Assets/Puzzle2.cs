using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2 : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] squares;
    public Button[] squareButtons;
    public Button screenButton;
    private bool screenOn;
    private bool solved = false;
    private bool[] buttonPressed = { false, false, false};
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (screenButton.pressed && screenOn == false) {
            screenOn = true;
            squares[1].SetActive(true);
        }

        if (screenOn && !solved) {
            for (int i = 0; i < squareButtons.Length; i++)
            {
                if (squareButtons[i].pressed)
                {
                    if (buttonPressed[i] == true)
                    {
                        // do nothing
                    }
                    else
                    {
                        squares[i].SetActive(!squares[i].activeInHierarchy);
                        if (i + 1 < squares.Length) {
                            squares[i+1].SetActive(!squares[i+1].activeInHierarchy);
                        }
                        if (i - 1 >= 0)
                        {
                            squares[i - 1].SetActive(!squares[i - 1].activeInHierarchy);
                        }
                        buttonPressed[i] = true;
                    }
                }
                else {
                    buttonPressed[i] = false;
                }
            }
            bool allEnabled = true;
            for (int i = 0; i < squareButtons.Length; i++)
            {
                if (!squares[i].activeInHierarchy) {
                    allEnabled = false;
                }
            }
            if (allEnabled) {
                solved = true;
                gameManager.puzzle2 = true;
            }
        }

       
    }
}
