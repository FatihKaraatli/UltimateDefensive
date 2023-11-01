using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCastleChoose : MonoBehaviour
{
    public GameObject[] castles;

    void Start()
    {
        ChooseCastle(PlayerPrefs.GetInt("currentcastleindex"));
    }


    private void ChooseCastle(int index)
    {
        for (int i = 0; i < castles.Length; i++)
        {
            if (i == index)
            {
                castles[i].SetActive(true);
            }
            else
            {
                castles[i].SetActive(false);
            }
        }
    }
}
