using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneTrailer : MonoBehaviour
{
    public GameObject[] huds;
    private GameObject[] enemies;
    private bool hudsControl;
    public GameObject[] environments;
    void Start()
    {
        hudsControl = true;
    } 

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (Input.GetKeyDown(KeyCode.H) && hudsControl)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            for (int i = 0; i < huds.Length; i++)
            {
                huds[i].SetActive(false);
            }
            hudsControl = false;
        }
        else if (Input.GetKeyDown(KeyCode.H) && !hudsControl)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.GetChild(0).gameObject.SetActive(true);
            }

            for (int i = 0; i < huds.Length; i++)
            {
                huds[i].SetActive(true);
            }
            hudsControl = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetFloat("level" , PlayerPrefs.GetFloat("level") + 45);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefs.SetFloat("level", 0);
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
                for (int i = 0; i<environments.Length;i++)
                {
                    if (i == PlayerPrefs.GetInt("environment"))
                        environments[i].SetActive(true);
                    else
                        environments[i].SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
