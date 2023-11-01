using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    public GameObject blood;

    [SerializeField] private EnemyMovement enemyMovement;

    public Slider healthBar;
    public GameObject healthBarGameObject;

    private bool is_count_increase;

    public Animator animator;

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

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "arrow")
        {
            if (health > 0)
            {
                animator.SetTrigger("hit");
                GameObject bloodImpact = Instantiate(blood, other.gameObject.transform.position, Quaternion.identity);
                Destroy(bloodImpact, 1f);
                
                other.GetComponent<MeshRenderer>().enabled = false;
                other.GetComponent<BoxCollider>().enabled = false;
                health -= other.GetComponent<Arrow>().damage;
                healthBar.value -= other.GetComponent<Arrow>().damage;
            }
            
            if (health <= 0)
            {
                if (!is_count_increase)
                {
                    throw_coin.SetActive(true);
                    rigbody2D.bodyType = RigidbodyType2D.Dynamic;
                    rigbody2D.AddForce(new Vector3(0,750,0));
                    Destroy(throw_coin, 0.75f);
                    is_count_increase = true;
                    PlayerPrefs.SetFloat("killcount", PlayerPrefs.GetFloat("killcount") + 1);
                    PlayerPrefs.SetFloat("killcountlevel", PlayerPrefs.GetFloat("killcountlevel") + 1);
                    PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + 150);
                }
                
                gameObject.tag = "Untagged";
                Destroy(healthBarGameObject);
                enemyMovement.animator.SetBool("dead", true);
                gameObject.GetComponent<EnemyMovement>().enabled = false;
                Destroy(gameObject , 3f);
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
