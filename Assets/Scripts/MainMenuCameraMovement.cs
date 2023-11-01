using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 mainPosition;
    private Quaternion mainRotation;


    public GameObject balistaRot;
    public GameObject castleRot;
    public GameObject towerRot;

    public GameObject animatedCam;

    private Touch touch;

    bool control;

    void Start()
    {
        PlayerPrefs.SetString("main", "null");
        mainPosition = transform.position;
        mainRotation = transform.rotation;
        control = true;
    }
    void Update()
    {
        if (PlayerPrefs.GetString("main") == "balista")
        {
            Invoke("GameObjectControl", 0.5f);
            gameObject.transform.parent = balistaRot.transform;
            if (!control)
            {        
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    balistaRot.transform.Rotate(0, 100*Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    balistaRot.transform.Rotate(0, -1* 100 * Time.deltaTime, 0);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(1.5f, 20f, -17.75f), speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(25f, 190f, transform.rotation.z), speed * Time.deltaTime);
            }
        }
        else if (PlayerPrefs.GetString("main") == "castle")
        {
            Invoke("GameObjectControl", 0.5f);
            gameObject.transform.parent = castleRot.transform;
            if (!control)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    castleRot.transform.Rotate(0, 100 * Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    castleRot.transform.Rotate(0, -1 * 100 * Time.deltaTime, 0);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(0f, 5f, 7.5f), speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 180f, transform.rotation.z), speed * Time.deltaTime);
            }
        }
        else if (PlayerPrefs.GetString("main") == "tower")
        {
            Invoke("GameObjectControl", 0.5f);
            gameObject.transform.parent = towerRot.transform;
            if (!control)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    towerRot.transform.Rotate(0, 100 * Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    towerRot.transform.Rotate(0, -1 * 100 * Time.deltaTime, 0);
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(-7f, 14f, -5f), speed * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(25f, 210f, transform.rotation.z), speed * Time.deltaTime);
            }           
        }
        else if (PlayerPrefs.GetString("main") == "task")
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(8.75f, 4.6f, -16.5f), speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 155f, transform.rotation.z), speed * Time.deltaTime);
        }
        else
        {
            control = true;
            gameObject.transform.parent = animatedCam.transform;
            transform.position = Vector3.Lerp(transform.position, mainPosition, speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, mainRotation, speed * Time.deltaTime);
        }
    }

    public void GameObjectControl()
    {
        control = false;
    }

}
