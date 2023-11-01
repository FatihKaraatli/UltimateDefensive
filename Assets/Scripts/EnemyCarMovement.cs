using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarMovement : MonoBehaviour
{
    public GameObject[] carPieces;
    public GameObject[] enemiesInCar;

    GameObject[] enemies;
    
    float min;
    int tmp = 0;

    private bool touch = false;

    [SerializeField] private EnemyCarHealth enemyCarHealth;

    public float moveSpeed;


    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("tower");
        if (enemies.Length == 0)
        {
            enemies = GameObject.FindGameObjectsWithTag("castle");
        }

        if (enemies.Length > 0)
        {
            min = Vector3.Distance(enemies[0].gameObject.transform.position, gameObject.transform.position);

            for (int i = 0; i < enemies.Length; i++)
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

        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tower")
        {
            CarCrash();
        }
        else if (other.gameObject.tag == "castle")
        {
            CarCrash();
        }
        else if (other.gameObject.tag == "enemy" || other.gameObject.tag == "arrow" || other.gameObject.tag == "piece")
        {
            return;
        }
        else
        {
            touch = false;
        }

    }

    public void CarCrash()
    {
        touch = true;
        for (int i = 0; i < carPieces.Length; i++)
        {
            carPieces[i].GetComponent<Collider>().isTrigger = false;
            carPieces[i].GetComponent<Rigidbody>().useGravity = true;
            Destroy(carPieces[i], 2.5f);
        }
        for (int i = 0; i < enemiesInCar.Length; i++)
        {
            enemiesInCar[i].SetActive(true);
        }
        gameObject.tag = "Untagged";
        Destroy(enemyCarHealth.healthBarGameObject);
        if (gameObject.GetComponent<BoxCollider>() != null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (gameObject.GetComponent<MeshCollider>() != null)
        {
            gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
