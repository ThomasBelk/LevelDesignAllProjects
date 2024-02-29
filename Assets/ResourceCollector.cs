using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollector : MonoBehaviour
{
    public float resourceDistance = 2f;
    private FadingText FadingText;
    private bool isInterating = false;
    // Start is called before the first frame update
    void Start()
    {
        FadingText = FindObjectOfType<FadingText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo , resourceDistance))
        {
            // Debug.Log("hit");
            if (hitInfo.transform.gameObject.CompareTag("Resource") && isInterating)
            {
                ResourceSource s = hitInfo.transform.gameObject.GetComponent<ResourceSource>();
                if (s != null)
                {
                    s.GetResource();
                }
            }
        }
    }

    public void SetIsInteracting(bool b)
    {
        isInterating = b;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * resourceDistance);
    }

}
