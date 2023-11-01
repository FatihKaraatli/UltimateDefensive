using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerExplosion : MonoBehaviour
{
    public float expForce, radius;
    public GameObject mainObject;

    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.M))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearyby in colliders)
            {
                Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
                if (rigg != null)
                {
                    rigg.AddExplosionForce(expForce, transform.position, radius);
                }
            }
        }

        Destroy(mainObject, 5f);
    }
}
