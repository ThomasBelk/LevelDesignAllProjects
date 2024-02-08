using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoubleDoor : MonoBehaviour
{
    public OpenDoor door1;
    public OpenDoor door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            door1.isOpening = true;
            door2.isOpening = true;
            door1.startTime = Time.time;
            door2.startTime = door1.startTime;
        }
    }
}
