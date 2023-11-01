using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windmill : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(5f * speed * Time.deltaTime, 0f, 0f);
    }
}
