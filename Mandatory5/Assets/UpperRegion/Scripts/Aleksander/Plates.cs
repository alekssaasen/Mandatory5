using UnityEngine;

public class Plates : MonoBehaviour
{
    public ElevatorPuzzle Manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Manipulatable" || other.tag == "Player")
        {
            Manager.PressurePlateDown();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Manager.PressurePlateUp();
    }

}
