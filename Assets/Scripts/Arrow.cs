using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage;

    public LayerMask layer;
    public void Start()
    {
        if (gameObject.name == "FirstBalistaArrow" || gameObject.name == "SecondBalistaArrow" || gameObject.name == "ThirdBalistaArrow" || gameObject.name == "FourthBalistaArrow" || gameObject.name == "FifthBalistaArrow(Canon)")
        {
            if (PlayerPrefs.GetInt("currentbalistaindex") == 0)
            {
                damage = PlayerPrefs.GetFloat("firstbalistapower");
            }
            else if (PlayerPrefs.GetInt("currentbalistaindex") == 1)
            {
                damage = PlayerPrefs.GetFloat("secondbalistapower");
            }
            else if (PlayerPrefs.GetInt("currentbalistaindex") == 2)
            {
                damage = PlayerPrefs.GetFloat("thirdbalistapower");
            }
            else if (PlayerPrefs.GetInt("currentbalistaindex") == 3)
            {
                damage = PlayerPrefs.GetFloat("fourthbalistapower");
            }
            else if (PlayerPrefs.GetInt("currentbalistaindex") == 4)
            {
                damage = PlayerPrefs.GetFloat("fifthbalistapower");
            }
        }
        else if (gameObject.name == "FirstTowerArrow" || gameObject.name == "SecondTowerArrow" || gameObject.name == "ThirdTowerArrow" || gameObject.name == "FourthTowerArrow" || gameObject.name == "FifthTowerArrow(Canon)")
        {
            if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 0)
            {
                damage = PlayerPrefs.GetFloat("firsttowerbalistapower");
            }
            else if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 1)
            {
                damage = PlayerPrefs.GetFloat("secondtowerbalistapower");
            }
            else if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 2)
            {
                damage = PlayerPrefs.GetFloat("thirdtowerbalistapower");
            }
            else if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 3)
            {
                damage = PlayerPrefs.GetFloat("fourthtowerbalistapower");
            }
            else if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 4)
            {
                damage = PlayerPrefs.GetFloat("fifthtowerbalistapower");
            }
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer)
        {
            Debug.Log(other.gameObject.layer);
            if (this.gameObject.GetComponent<Rigidbody>())
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }*/
    /*public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == layer)
        {
            Debug.Log("aaaaa");
            if (this.gameObject.GetComponent<Rigidbody>())
            {
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }*/

}
