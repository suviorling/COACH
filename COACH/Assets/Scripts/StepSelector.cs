using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] stepPanels;
    [SerializeField] private GameObject[] stepToggles;
    [SerializeField] private List<GameObject> pinnedSteps = new List<GameObject>();

    private bool toggleOn = false;
    private int onGoingStep = 0;

    private void Start()
    {
        stepPanels[onGoingStep].SetActive(true);
        
        
    }

    public void ChangeStepPanel()
    {
        onGoingStep++;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[onGoingStep - 1].SetActive(false);                
    }

    public void StepSelect(int stepNumber)
    {
        onGoingStep = stepNumber;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[onGoingStep - 1].SetActive(false);
    }

    public void PinStep()
    {        
        if (!toggleOn)
        {            
            pinnedSteps.Add(stepPanels[onGoingStep]);
            toggleOn = true;
        }
        else
        {
            pinnedSteps.Remove(stepPanels[onGoingStep]);
            toggleOn = false;
        }               
    }

    public void ToStartPage()
    {
        int lastStep = onGoingStep;
        Debug.Log(lastStep);
        onGoingStep = 0;
        
        stepPanels[onGoingStep].SetActive(true);
        CheckPinnedSteps();
        stepPanels[lastStep].SetActive(false);
    }

    private void CheckPinnedSteps()
    {
        for (int item = 0; item < 18; item++)
        {
            if (pinnedSteps.Contains(stepPanels[item]))
            {
                stepToggles[item - 1].SetActive(true);
            }
        }
    }
}
