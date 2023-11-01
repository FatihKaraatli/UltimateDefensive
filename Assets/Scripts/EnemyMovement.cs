using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject[] enemies;
    GameObject[] control;
    bool is_any_tower_alive = true;
    float min;
    int tmp = 0;

    public bool touch = false;

    public float moveSpeed;

    public Animator animator;

    private TowerHealth towerHealth;
    private CastleHealth castleHealth;

    public float damage;

    bool is_castle = false;
    bool is_tower = false;

    public void Start()
    {
        if (PlayerPrefs.GetFloat("level") == 0)
        {
            PlayerPrefs.SetFloat("damage", damage);
            DecideDamage();
        }
        else
        {
            damage = PlayerPrefs.GetFloat("damage");
            DecideDamage();
        }
    }

    void Update()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("tower");
        Debug.Log(enemies.Length);
        if (enemies.Length == 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("castle");
        }

        if (enemies.Length > 0)
        {
            min = Vector3.Distance(enemies[0].gameObject.transform.position, gameObject.transform.position);

            for (int i = 1; i < enemies.Length; i++)
            {
                float dis = Vector3.Distance(enemies[i].gameObject.transform.position, gameObject.transform.position);
                if (Mathf.Abs(min) >= Mathf.Abs(dis))
                {
                    min = dis;
                    tmp = i;
                }
            }

            
            if (!touch)
            {
                if (enemies.Length == 1)
                {
                    tmp = 0;
                }
                gameObject.transform.LookAt(new Vector3(enemies[tmp].transform.position.x,
                                                            gameObject.transform.position.y,
                                                            enemies[tmp].transform.position.z));

                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(enemies[tmp].transform.position.x,
                                                        gameObject.transform.position.y,
                                                        enemies[tmp].transform.position.z), moveSpeed * Time.deltaTime);
            }

        }
        else
        {
            animator.SetTrigger("dance");
        }
        Control();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tower")
        {
            towerHealth = enemies[tmp].GetComponent<TowerHealth>();

            animator.SetBool("walk_attack", true);
            touch = true;
            is_tower = true;
            is_castle = false;
        }
        else if (other.gameObject.tag == "castle")
        {
            castleHealth = enemies[tmp].GetComponent<CastleHealth>();

            animator.SetBool("walk_attack", true);
            touch = true;
            is_castle = true;
            is_tower = false;
        }
        else if (other.gameObject.tag == "enemy" || other.gameObject.tag == "arrow" || other.gameObject.tag == "piece")
        {
            return;
        }
        else
        {
            is_castle = false;
            is_tower = false;
            touch = false;
            animator.SetBool("walk_attack", false);
        }

    }

    public void Control()
    {
        control = GameObject.FindGameObjectsWithTag("tower");

        if (control.Length == 0 && is_any_tower_alive)
        {
            is_tower = false;
            touch = false;
            animator.SetBool("walk_attack", false);
            is_any_tower_alive = false;
        }
    }


    public void Attack()
    {
        if (is_tower)
        {
            if (towerHealth != null)
            {
                towerHealth.TowerDamage(damage);
                float dmg = towerHealth.towerHealth;
                if (dmg <= 0)
                {
                    touch = false;
                    animator.SetBool("walk_attack", false);
                }
            }
            else
            {
                touch = false;
                animator.SetBool("walk_attack", false);
            }
        }
        else if (is_castle)
        {
            if (castleHealth != null)
            {
                animator.SetBool("walk_attack", true);
                touch = true;
                castleHealth.CastleDamage(damage);
                float dmg = castleHealth.castleHealth;
                if (dmg <= 0)
                {
                    touch = false;
                    animator.SetTrigger("dance");
                    //animator.SetBool("walk_attack", false);
                }
            }
            else
            {
                touch = false;
                animator.SetBool("walk_attack", false);
            }
        }
        else
        {
            touch = false;
            animator.SetBool("walk_attack", false);
        }
    }

    public void DecideDamage()
    {
        if (PlayerPrefs.GetFloat("level") % 20 == 0)
        {
            damage = PlayerPrefs.GetFloat("damage") + 2;
            PlayerPrefs.SetFloat("damage", damage);
        }
    }

}
