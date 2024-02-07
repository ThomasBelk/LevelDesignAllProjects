using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator door;

    private bool openTrigger = false;
    private bool closeTrigger = false;

    private void openTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                door.Play("Door_open", 0, 0.0f);
                gameObject.SetActive(false);
            }

            else if (closeTrigger)
            {
                door.Play("Door_close", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
