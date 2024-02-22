using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBoard : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] Quaternion targetRotation;
    private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

}
