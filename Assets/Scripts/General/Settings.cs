using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class Settings : MonoBehaviour
{
    public Material selectedMaterial;
    public GameObject snapButton;
    public GameObject smoothButton;
    public GameObject XROrigin;
    public float volume = 0.01f;
    private Material defaultMaterial;
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = volume;
        defaultMaterial = snapButton.GetComponent<MeshRenderer>().material;
        enableSnap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enableSnap() {
        smoothButton.GetComponent<MeshRenderer>().material = defaultMaterial;
        snapButton.GetComponent<MeshRenderer>().material = selectedMaterial;

        XROrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        XROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
    }

    public void enableSmooth()
    {
        smoothButton.GetComponent<MeshRenderer>().material = selectedMaterial;
        snapButton.GetComponent<MeshRenderer>().material = defaultMaterial;

        XROrigin.GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
        XROrigin.GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
    }
}
