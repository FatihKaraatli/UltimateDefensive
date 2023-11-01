using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyCarHealth : MonoBehaviour
{
    [SerializeField] private float health;
    public GameObject impact;

    [SerializeField] private EnemyCarMovement enemyCarMovement;

    public Slider healthBar;
    public GameObject healthBarGameObject;

    private bool is_count_increase;

    public Rigidbody2D rigbody2D;
    public GameObject throw_coin;

    void Start()
    {
        if (PlayerPrefs.GetFloat("level") == 0)
        {
            PlayerPrefs.SetFloat("health", health);
            DecideHealth();
        }
        else
        {
            health = PlayerPrefs.GetFloat("health");
            DecideHealth();
        }

        is_count_increase = false;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "arrow")
        {
            if (health > 0)
            {
                //Destroy(other);
                GameObject bloodImpact = Instantiate(impact, other.gameObject.transform.position, Quaternion.identity);
                bloodImpact.transform.position = new Vector3(bloodImpact.transform.position.x - 0.2f , bloodImpact.transform.position.y + 1.75f , bloodImpact.transform.position.z - 7f);
                Destroy(bloodImpact, 1f);
                other.GetComponent<MeshRenderer>().enabled = false;
                if (other.GetComponent<BoxCollider>() != null)
                {
                    other.GetComponent<BoxCollider>().enabled = false;
                }
                else if (other.GetComponent<MeshCollider>() != null)
                {
                    other.GetComponent<MeshCollider>().enabled = false;
                }

                health -= other.GetComponent<Arrow>().damage;
                healthBar.value -= other.GetComponent<Arrow>().damage;
            }

            if (health <= 0)
            {
                if (!is_count_increase)
                {
                    throw_coin.SetActive(true);
                    rigbody2D.bodyType = RigidbodyType2D.Dynamic;
                    rigbody2D.AddForce(new Vector3(0, 750, 0));
                    Destroy(throw_coin, 0.75f);
                    is_count_increase = true;
                    PlayerPrefs.SetFloat("destroyvehiclecount", PlayerPrefs.GetFloat("destroyvehiclecount") + 1);
                    PlayerPrefs.SetFloat("destroyvehiclecountlevel", PlayerPrefs.GetFloat("destroyvehiclecountlevel") + 1);
                    PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + 250);
                }
                
                Destroy(healthBarGameObject);
                enemyCarMovement.CarCrash();
                gameObject.tag = "Untagged";
            }
        }
    }

    public void DecideHealth()
    {
        if (PlayerPrefs.GetFloat("level") % 20 == 0)
        {
            health = PlayerPrefs.GetFloat("health") + 2;
            PlayerPrefs.SetFloat("health", health);
        }
    }
}
