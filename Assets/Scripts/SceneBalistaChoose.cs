using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBalistaChoose : MonoBehaviour
{

    public GameObject[] balista;

    void Start()
    {
        ChooseBalista(PlayerPrefs.GetInt("currentbalistaindex"));
    }


    private void ChooseBalista(int index)
    {
        for (int i = 0; i < balista.Length; i++)
        {
            if (i == index)
            {
                balista[i].SetActive(true);
            }
            else
            {
                balista[i].SetActive(false);
            }
        }
    }
}
