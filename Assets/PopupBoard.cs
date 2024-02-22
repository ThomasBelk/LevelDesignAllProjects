using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupBoard : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] Vector3 targetRotation;
    private bool isInRange = false;
    private bool hasPlayedSound = false;
    [SerializeField] AudioClip creeck;
    public bool isCivilian = true;
    // Start is called before the first frame update

    void Update()
    {
        if (isInRange)
        {
            if (!hasPlayedSound)
            {
                AudioSource.PlayClipAtPoint(creeck, transform.position);
                hasPlayedSound = true;
            }
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetRotation), speed * Time.deltaTime);
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
