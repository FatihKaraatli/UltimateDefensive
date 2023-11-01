using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIA : MonoBehaviour
{
    GameObject[] enemies;
    float min;
    int tmp = 0;

    private bool is_any_enemy_alive;

    public float strenght = 0;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    [SerializeField] private Recoil gunRecoil;

    private AudioSource audioSource;
    public AudioClip arrowSound;

    public float shotInterval = 0.5f;

    private float shotTime  = 0;

    private Quaternion startRot;


    void Start()
    {
        startRot = transform.rotation;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
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

            gameObject.transform.LookAt(new Vector3(enemies[tmp].transform.position.x,
                                                        enemies[tmp].transform.position.y + 4.5f,
                                                        enemies[tmp].transform.position.z));

            is_any_enemy_alive = true;
        }
        else
        {
            transform.rotation = startRot;
            is_any_enemy_alive = false;
        }
        
    }

    private void FixedUpdate()
    {
        if (is_any_enemy_alive && (Time.time - shotTime) > shotInterval)
        {
            TowerArrowShotBegin();
        }
    }

    public void TowerArrowShotBegin()
    {
        shotTime = Time.time;
        audioSource.PlayOneShot(arrowSound);
        gunRecoil.RecoilArrow();
        GameObject bullet_throw = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        bullet_throw.gameObject.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.gameObject.transform.forward * strenght * Time.deltaTime);
        Destroy(bullet_throw, 4f);
    }

}
