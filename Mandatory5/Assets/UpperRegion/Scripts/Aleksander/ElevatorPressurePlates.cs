using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPressurePlates : MonoBehaviour
{
    public Elevator elevator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            elevator.UseElevator();
        }
    }
}
