using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 100f;
    public Transform player;
    public float xrotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xrotation -= mouseY;
        //prevent the camera from rotating beyond a certain point
        xrotation = Mathf.Clamp(xrotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
