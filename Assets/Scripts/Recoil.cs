using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 originalRotation;
    void Start()
    {
        originalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Recoil();
        }
    }

    public void RecoilArrow()
    {
        AddRecoil();
        Invoke("BackRecoil", 0.1f);
    }

    private void StopRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void AddRecoil()
    {
        transform.localEulerAngles = originalRotation;
    }

    private void BackRecoil()
    {
        StopRecoil();
    }
}
