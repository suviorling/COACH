using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StepSelector : MonoBehaviour
{
    [Tooltip("List of all step panel gameobjects")]
    public GameObject[] stepPanels;

    [Tooltip("List of all buttons in steps menu")]
    [SerializeField] private List<GameObject> stepButtons = new List<GameObject>();

    [Tooltip("List of all activatable step pin icons in steps menu")]
    [SerializeField] private GameObject[] stepToggles;

    [Tooltip("List of all steps that have been pinned")]
    public List<GameObject> pinnedSteps = new List<GameObject>();

    public int onGoingStep = 0;


    private void Start()
    {
        stepPanels[onGoingStep].SetActive(true);
    }

    // Change to next panel when clicking next
    public void ChangeStepPanel()
    {
        onGoingStep++;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[onGoingStep - 1].SetActive(false);                
    }

    // Change to specific panel when clicked from the steps menu
    // based on the buttons index in the list
    public void ChangeToSpecificStepPanel()
    {
        GameObject ClickedButtonName = EventSystem.current.currentSelectedGameObject;
        onGoingStep = stepButtons.IndexOf(ClickedButtonName) + 1;
        stepPanels[onGoingStep].SetActive(true);
        stepPanels[0].SetActive(false);
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

    // Goes through a list and checks wheater any steps are pinned/unpinned
    // and pins/unpins then in the steps menu
    private void CheckPinnedSteps()
    {
        for (int item = 1; item < 18; item++)
        {
            if (pinnedSteps.Contains(stepPanels[item]))
            {
                stepToggles[item - 1].SetActive(true);
            }
            else stepToggles[item - 1].SetActive(false);
        }
    }

    
}
