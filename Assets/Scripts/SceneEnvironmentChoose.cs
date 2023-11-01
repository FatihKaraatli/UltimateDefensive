using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnvironmentChoose : MonoBehaviour
{

    public GameObject[] environments;

    void Start()
    {
        if (PlayerPrefs.GetInt("environment") > 2)
        {
            PlayerPrefs.SetInt("environment" , 0);
        }
        for (int i = 0; i < environments.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("environment"))
            {
                environments[i].SetActive(true);
            }
            else
            {
                environments[i].SetActive(false);
            }
        }

        if (PlayerPrefs.GetInt("environment") == 0)
        {
            RenderSettings.fogColor = new Color(0.1137255f , 0.3843138f , 0.1176471f);
        }
        else if (PlayerPrefs.GetInt("environment") == 1)
        {
            RenderSettings.fogColor = new Color(0.509434f, 0.5073662f, 0.1898362f);
        }
        else if (PlayerPrefs.GetInt("environment") == 2)
        {
            RenderSettings.fogColor = new Color(0.5764706f, 0.7019608f, 0.8784314f);
        }

        PlayerPrefs.SetInt("environment", PlayerPrefs.GetInt("environment") + 1);
    }

    
}
