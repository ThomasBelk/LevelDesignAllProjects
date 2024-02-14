using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PictureFrameBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] private float holdDistance;
    [SerializeField] private float verticalHoldDistance = 0.5f;
    [SerializeField] private float horizonatalHoldDistance = 0.5f;
    [SerializeField] private float pickupSpeed;
    [SerializeField] private Vector3 localRotation;
    private Vector3 initalPos;
    private Quaternion initalRotation;
    private Vector3 initalScale;
    void Start()
    {
        initalPos = transform.localPosition;
        initalRotation = transform.localRotation;
        initalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact()
    {
        gameObject.transform.parent = Camera.main.transform;
        transform.localPosition = new Vector3(horizonatalHoldDistance, verticalHoldDistance, holdDistance);
        transform.localRotation = Quaternion.Euler(localRotation);
    }

    public void Drop()
    {
        gameObject.transform.parent = null;
        transform.localScale = initalScale;
        transform.localPosition = initalPos;
        transform.localRotation = initalRotation;
    }

}
