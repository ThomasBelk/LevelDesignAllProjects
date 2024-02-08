using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private bool shouldOpen = false;
    [SerializeField] private Vector3 endDegrees = new Vector3(0f, -120f, 0f);
    [SerializeField] private Vector3 startDegrees = Vector3.zero;
    [SerializeField] private float speed = 1f;
    private Vector3 currentDegrees;
    public bool isOpening = false;
    [SerializeField] private float timeOpen = 2f;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        currentDegrees = startDegrees;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldOpen && isOpening)
        {
            //Debug.Log("Opening");
            currentDegrees = Vector3.Lerp(currentDegrees, endDegrees, speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(currentDegrees);
            if (Time.time > startTime + timeOpen)
            {
                isOpening = false;
            }
        }
        else
        {
            //Debug.Log("Closing");
            currentDegrees = Vector3.Lerp(currentDegrees, startDegrees, speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(currentDegrees);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpening = true;
            startTime = Time.time;
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        isOpening = false;
    //    }
    //}
}