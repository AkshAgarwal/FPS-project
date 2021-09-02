using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mousesens;
    [SerializeField] Camera cam;
    float MouseX;
    float MouseY;
    float Xrotation;
    // Start is called before the first frame update
    void Start()
    {
        mousesens = 100f;
        Xrotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MouseX = Input.GetAxis("Mouse X")*mousesens*Time.deltaTime;
        MouseY = Input.GetAxis("Mouse Y")*mousesens*Time.deltaTime;
        Xrotation -= MouseY;
        Xrotation = Mathf.Clamp(Xrotation, -90f, 90f);
        cam.transform.localRotation = Quaternion.Euler(Xrotation, 0f, 0f);
        transform.Rotate(Vector3.up*MouseX);
    }
}
