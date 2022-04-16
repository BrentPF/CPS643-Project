using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Puzzle4 : MonoBehaviour
{

    private string response = "";
    private string answer = "643";
    public TextMeshPro passcodeText;
    private bool pauseText = false;
    private Color defaultColour;
    private bool puzzleStarted = false;
    public Material orange, pink, blue;
    public GameObject[] orangeCylinders, pinkCylinders, blueCylinders;
    public GameObject[] ballObjects;
    public GameManager gameManager;
    private bool solved = false;
    // Start is called before the first frame update
    void Start()
    {
        defaultColour = passcodeText.color;
        passcodeText.text = response;
    }

    // Update is called once per frame
    void Update()
    {
        if (!solved && puzzleStarted) {
            bool allConnected = true;
            foreach (GameObject ballObject in ballObjects) {
                if (!ballObject.GetComponent<BallZone>().connected) {
                    allConnected = false;
                }
            }
            if (allConnected) {
                solved = true;
                puzzleStarted = false;
                gameManager.puzzle4 = true;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public IEnumerator addCharacter(string value) {
        if (!pauseText)
        {
            if (response.Length < 3)
            {
                response += value;
                passcodeText.text = response;
            }

            if (response.Length == 3)
            {
                if (response == answer)
                {
                    pauseText = true;
                    yield return new WaitForSeconds(1);
                    passcodeText.color = Color.green;
                    GetComponent<AudioSource>().enabled = true;
                    setBallColours();
                    puzzleStarted = true;
                }
                else
                {
                    pauseText = true;
                    yield return new WaitForSeconds(1);
                    passcodeText.color = Color.red;
                    yield return new WaitForSeconds(2);
                    pauseText = false;
                    response = "";
                    passcodeText.color = defaultColour;
                    passcodeText.text = response;
                }
            }
        }
    }

    private void setBallColours() {
        foreach (GameObject cylinder in orangeCylinders) {
            cylinder.GetComponent<MeshRenderer>().material = orange;
        }

        foreach (GameObject cylinder in pinkCylinders)
        {
            cylinder.GetComponent<MeshRenderer>().material = pink;
        }

        foreach (GameObject cylinder in blueCylinders)
        {
            cylinder.GetComponent<MeshRenderer>().material = blue;
        }

        foreach (GameObject ballObject in ballObjects) {
            ballObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
