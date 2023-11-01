using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerHealth : MonoBehaviour
{

    public float towerHealth;
    public GameObject[] towerBalista;

    public Slider healthBar;

    public GameObject piece;

    private float healthCount;
    private bool is_fire_occur =false;

    public GameObject[] fires;
    void Start()
    {
        if (PlayerPrefs.GetInt("currenttowerindex") == 0)
        {
            towerHealth = PlayerPrefs.GetFloat("firsttowerhealth");
        }
        else if (PlayerPrefs.GetInt("currenttowerindex") == 1)
        {
            towerHealth = PlayerPrefs.GetFloat("secondtowerhealth");
        }
        else if (PlayerPrefs.GetInt("currenttowerindex") == 2)
        {
            towerHealth = PlayerPrefs.GetFloat("thirdtowerhealth");
        }
        else if (PlayerPrefs.GetInt("currenttowerindex") == 3)
        {
            towerHealth = PlayerPrefs.GetFloat("fourthtowerhealth");
        }
        else if (PlayerPrefs.GetInt("currenttowerindex") == 4)
        {
            towerHealth = PlayerPrefs.GetFloat("fifthtowerhealth");
        }

        healthCount = towerHealth;
        healthBar.maxValue = towerHealth;
        healthBar.value = healthBar.maxValue;
    }

    public void TowerDamage(float damage)
    {
        if (towerHealth <= healthCount/2 && !is_fire_occur)
        {
            is_fire_occur = true;
            for (int i = 0; i < fires.Length ; i++)
            {
                fires[i].SetActive(true);
            }
        }
        towerHealth -= damage;
        healthBar.value -= damage;
        if (towerHealth <= 0)
        {
            piece.SetActive(true);
            Destroy(towerBalista[PlayerPrefs.GetInt("currenttowerbalistaindex")]);
            Destroy(gameObject);
        }
    }

}
