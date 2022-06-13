using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Animator ElevatorAnim;
    public GameObject elevatorText;
    public Animator elevatorTextAnim;

    private bool isActivated;

    public void UseElevator()
    {

        if (isActivated)
        {
            ElevatorAnim.SetTrigger("Activate");

            
        }
    }

    public void ActivateElevator(bool state)
    {
        isActivated = state;
        if (state)
        {
            elevatorText.SetActive(true);
            elevatorTextAnim.SetTrigger("Start");
        }
    }

    
}
