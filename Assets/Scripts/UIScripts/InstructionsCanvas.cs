using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsCanvas : MonoBehaviour
{
    public GameObject instructionsCanvas;
    public GameObject mainCanvas;

    public void ShowInstructions()
    {
        instructionsCanvas.SetActive(true);
        mainCanvas.SetActive(false);
    }

    public void DeactivateCanvas()
    {
        mainCanvas.SetActive(true);
        instructionsCanvas.SetActive(false);
    }
}
