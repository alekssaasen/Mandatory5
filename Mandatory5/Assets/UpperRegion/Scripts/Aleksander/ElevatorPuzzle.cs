using UnityEngine;

public class ElevatorPuzzle : MonoBehaviour
{

    private int PressurePlatesActivated;

    public Elevator elevator;
 

    public void PressurePlateDown()
    {
        PressurePlatesActivated++;
        if (PressurePlatesActivated == 2)
        {
            elevator.ActivateElevator(true);
        }
    }
    public void PressurePlateUp()
    {
        PressurePlatesActivated--;
       
    }
}
