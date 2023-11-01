using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject huds;
    private bool hudsControl;
    public GameObject[] environments;
    void Start()
    {
        hudsControl = true;
        PlayerPrefs.SetFloat("money", 9999999999);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.SetFloat("money", 9999999999);
        }
        if (Input.GetKeyDown(KeyCode.H) && hudsControl)
        {
            huds.SetActive(false);
            hudsControl = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && !hudsControl)
        {
            huds.SetActive(true);
            hudsControl = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if ((PlayerPrefs.GetInt("environment") + 1) > 2)
            {
                PlayerPrefs.SetInt("environment", 0);
                environments[0].SetActive(true);
                environments[1].SetActive(false);
                environments[2].SetActive(false);
            }
            else
            {
                PlayerPrefs.SetInt("environment", PlayerPrefs.GetInt("environment") + 1);
                for (int i = 0; i < environments.Length; i++)
                {
                    if (i == PlayerPrefs.GetInt("environment"))
                        environments[i].SetActive(true);
                    else
                        environments[i].SetActive(false);
                }
            }
        }
    }
}
