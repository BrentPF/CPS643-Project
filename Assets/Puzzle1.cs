using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1 : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject rightController;
    public GameObject leftController;
    public bool inPuzzleZone = false;
    public InputController inputController;
    public GameObject okHand;
    public GameObject pointUp;
    public GameObject fist;
    private int level = 1;
    private bool transitioning = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inPuzzleZone) {
            if (level == 1)
            {
                if (leftController.transform.localEulerAngles.x < 300 && leftController.transform.localEulerAngles.x > 200 && !transitioning) { 
                    if (inputController.triggerLPressed && !inputController.gripLPressed)
                    {
                        transitioning = true;
                        StartCoroutine(changeLevel(okHand, pointUp));
                    }
                }
            }
            else if (level == 2)
            {
                
                if (rightController.transform.localEulerAngles.x < 300 && rightController.transform.localEulerAngles.x > 200 && !transitioning)
                {
                    if (!inputController.triggerRPressed && inputController.gripRPressed)
                    {
                        transitioning = true;
                        StartCoroutine(changeLevel(pointUp, fist));
                    }
                }
            }
            else if (level == 3)
            {
                Debug.Log(rightController.transform.localEulerAngles.x);
                if (leftController.transform.localEulerAngles.x < 300 && leftController.transform.localEulerAngles.x > 200 && !transitioning)
                {
                    if (inputController.triggerLPressed && inputController.gripLPressed)
                    {
                        transitioning = true;
                        StartCoroutine(changeLevel(fist));
                    }
                }
            }
            
        }
    }

    IEnumerator changeLevel(GameObject obj, GameObject nextObj = null) {
        obj.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        level += 1;
        if (nextObj==null)
        {
            gameManager.puzzle1 = true;
        }
        yield return new WaitForSeconds(3);
        if (nextObj)
        {
            Debug.Log("not null");
            obj.SetActive(false);
            nextObj.SetActive(true);
        }
        Debug.Log("routine finish");
        transitioning = false;
    }
}
