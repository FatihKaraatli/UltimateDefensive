using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrow : MonoBehaviour
{

    public float strenght = 0;
    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    [SerializeField] private Recoil gunRecoil;

    private AudioSource audioSource;
    public AudioClip arrowSound;

    public float shotInterval = 0.5f;

    private float shotTime = 0;

    public Animator bowAnim;

    public CameraShake cameraShake;

    public GameObject smoke_VFX;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && (Time.time - shotTime) > shotInterval)
        {
            Fire();
        }
    }


    public void Fire()
    {
        shotTime = Time.time;
        audioSource.PlayOneShot(arrowSound);
        gunRecoil.RecoilArrow();
        bowAnim.SetTrigger("fire");
        if (PlayerPrefs.GetInt("currentbalistaindex") == 4)
        {
            cameraShake.shake = true;
            GameObject smoke = Instantiate(smoke_VFX, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Destroy(smoke, 1f);
            Invoke("ShakeStop", 0.25f);
        }
        GameObject bullet_throw = Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        bullet_throw.gameObject.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.gameObject.transform.forward * strenght * Time.deltaTime);
        Destroy(bullet_throw, 2.5f);
    }

    public void ShakeStop()
    {
        cameraShake.shake = false;
        cameraShake.shakeDuration = 0.15f;
    }


}
