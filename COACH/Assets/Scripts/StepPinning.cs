using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPinning : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private StepSelector stepSelector;
    private List<GameObject> pinnedSteps = new List<GameObject>();
    private GameObject[] stepPanels;
    private int onGoingStep;
    public bool toggleOn = false;

    private void Start()
    {
        stepSelector = canvas.GetComponent<StepSelector>();
        stepPanels = stepSelector.stepPanels;
    }
    public void PinStep()
    {
        onGoingStep = stepSelector.onGoingStep;
        pinnedSteps = stepSelector.pinnedSteps;

        if (!toggleOn)
        {
            pinnedSteps.Add(stepPanels[onGoingStep]);
            toggleOn = true;
            Debug.Log("!toggle");
        }
        else
        {
            pinnedSteps.Remove(stepPanels[onGoingStep]);
            toggleOn = false;
            Debug.Log("toggle");
        }
    }
}
