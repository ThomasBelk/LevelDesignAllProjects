using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 20f;
    [SerializeField] private float sens = 1000f;
    private float yRotation = -90f;
    private float xRotation = 0f;
    private float height;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos = newPos + transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            newPos = newPos - transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            newPos = transform.position - transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            newPos = transform.position + transform.right * speed * Time.deltaTime;
        }

        newPos.y = height;
        transform.position = newPos;


        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;


        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
