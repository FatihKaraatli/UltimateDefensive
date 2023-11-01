using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTowerAndTowerBalistaChoose : MonoBehaviour
{
    public GameObject[] towerbalista;
    public GameObject[] towers;

    void Start()
    {
        ChooseTowerBalista(PlayerPrefs.GetInt("currenttowerbalistaindex"));
        ChooseTower(PlayerPrefs.GetInt("currenttowerindex"));
    }


    private void ChooseTowerBalista(int index)
    {
        for (int i = 0; i < towerbalista.Length; i++)
        {
            if (i == index)
            {
                towerbalista[i].SetActive(true);
            }
            else
            {
                towerbalista[i].SetActive(false);
            }
        }
    }
    
    private void ChooseTower(int index)
    {
        for (int i = 0; i < towers.Length; i++)
        {
            if (i == index)
            {
                towers[i].SetActive(true);
            }
            else
            {
                towers[i].SetActive(false);
            }
        }
    }
}
