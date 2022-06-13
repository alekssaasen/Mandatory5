using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerFeedback : MonoBehaviour
{
    public GameObject entranceText;
    public Animator entranceAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            entranceText.SetActive(true);
            entranceAnim.SetTrigger("Start");
            
        }
    }
}
