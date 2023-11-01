using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalistaMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    float mouseX, mouseY;
    private Touch touch;
    Vector2 first_position;



    void Start()
    {
        rotationSpeed = PlayerPrefs.GetFloat("sensitivity");
        /*Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;*/
    }


    private void LateUpdate()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                CamControl();
            }

        }
        CamControl();
    }

    void CamControl()
    {
        
        rotationSpeed = PlayerPrefs.GetFloat("sensitivity");
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -30, 75);
        mouseX = Mathf.Clamp(mouseX, -67.5f, 67.5f);
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }
}
    
