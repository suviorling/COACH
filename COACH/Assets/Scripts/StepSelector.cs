using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StepSelector : MonoBehaviour
{
    [SerializeField] public GameObject[] stepPanels;
    [SerializeField] private List<GameObject> stepButtons = new List<GameObject>();
    [SerializeField] private GameObject[] stepToggles;
    [SerializeField] public List<GameObject> pinnedSteps = new List<GameObject>();

    
    public int onGoingStep = 0;

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

    public void ChangeToSpecificStepPanel()
    {
        GameObject ClickedButtonName = EventSystem.current.currentSelectedGameObject;
        onGoingStep = stepButtons.IndexOf(ClickedButtonName) + 1;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[0].SetActive(false);
    }

    public void StepSelect(int stepNumber)
    {
        onGoingStep = stepNumber;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[onGoingStep - 1].SetActive(false);
    }

    public void ToStartPage()
    {
        int lastStep = onGoingStep;
        onGoingStep = 0;
        
        stepPanels[onGoingStep].SetActive(true);
        CheckPinnedSteps();
        if (!stepPanels[lastStep].GetComponent<StepPinning>().toggleOn) stepToggles[lastStep-1].SetActive(false);
        stepPanels[lastStep].SetActive(false);
    }

    private void CheckPinnedSteps()
    {
        for (int item = 1; item < 18; item++)
        {
            if (pinnedSteps.Contains(stepPanels[item]))
            {
                stepToggles[item - 1].SetActive(true);
            }
        }
    }

    
}
