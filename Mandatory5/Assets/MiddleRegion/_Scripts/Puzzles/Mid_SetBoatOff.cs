using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_SetBoatOff : MonoBehaviour
{

    public bool canPressE;
    public Mid_Boat midBoat;
    public Animator boatAnim, buttonAnim;


    // Start is called before the first frame update
    void Start()
    {
        buttonAnim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPressE = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canPressE = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (canPressE)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                midBoat.MoveAnimalToBoat();
            }
        }

        if (midBoat.seatOneFilled == true && midBoat.playerTouchedBoat)
        {

        }
    }
}

