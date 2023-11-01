using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CastleHealth : MonoBehaviour
{
    public float castleHealth;
    public GameObject[] pieceOfCastle;

    public Slider healthBar;
    public GameObject healthBarGameObject;

    void Start()
    {
        if (PlayerPrefs.GetInt("currentcastleindex") == 0)
        {
            castleHealth = PlayerPrefs.GetFloat("firstcastlehealth");
        }
        else if (PlayerPrefs.GetInt("currentcastleindex") == 1)
        {
            castleHealth = PlayerPrefs.GetFloat("secondcastlehealth");
        }
        else if (PlayerPrefs.GetInt("currentcastleindex") == 2)
        {
            castleHealth = PlayerPrefs.GetFloat("thirdcastlehealth");
        }
        else if (PlayerPrefs.GetInt("currentcastleindex") == 3)
        {
            castleHealth = PlayerPrefs.GetFloat("fourthcastlehealth");
        }
        else if (PlayerPrefs.GetInt("currentcastleindex") == 4)
        {
            castleHealth = PlayerPrefs.GetFloat("fifthcastlehealth");
        }

        healthBar.maxValue = castleHealth;
        healthBar.value = healthBar.maxValue;
    }

    public void CastleDamage(float damage)
    {
        castleHealth -= damage;
        healthBar.value -= damage;
        if (castleHealth <= 0)
        {
            for (int i = 0; i < pieceOfCastle.Length; i++)
            {
                Destroy(pieceOfCastle[i]);
            }
            Destroy(healthBarGameObject);
            Destroy(gameObject);
        }
    }
}
