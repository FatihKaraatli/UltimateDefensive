using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorsButtonControl : MonoBehaviour
{
    public GameObject button;
    public WarriorArrows[] arrows;

    public void WarriorsFire()
    {
        for (int i = 0;i<arrows.Length;i++)
        {
            arrows[i].Fire();
        }
        button.SetActive(false);
    }
}
