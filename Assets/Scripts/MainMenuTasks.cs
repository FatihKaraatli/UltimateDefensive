using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuTasks : MonoBehaviour
{
    public TextMeshProUGUI killCount;
    public TextMeshProUGUI destroyVehicleCount;
    public TextMeshProUGUI levelCount;

    private float killtask;
    private float destroyvehicletask;
    private float leveltask;

    public GameObject taskRewardPanel;

    private int kill;
    private int vehicle;
    private int level;

    void Start()
    {
        if (PlayerPrefs.GetFloat("firstImplament") == 0)
        {
            killtask = 100;
            destroyvehicletask = 25;
            leveltask = 10;
            PlayerPrefs.SetFloat("killtask" , killtask);
            PlayerPrefs.SetFloat("destroyvehicletask", destroyvehicletask);
            PlayerPrefs.SetFloat("leveltask", leveltask);

            PlayerPrefs.SetFloat("firstImplament", 1);

        }
        kill = 0;
        vehicle = 0;
        level = 0;
    }

    void Update()
    {
        if (PlayerPrefs.GetFloat("killcount") > PlayerPrefs.GetFloat("killtask"))
        {
            kill++;
            PlayerPrefs.SetFloat("killtask", PlayerPrefs.GetFloat("killtask") + 100);
            taskRewardPanel.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("destroyvehiclecount") > PlayerPrefs.GetFloat("destroyvehicletask"))
        {
            vehicle++;
            PlayerPrefs.SetFloat("destroyvehicletask", PlayerPrefs.GetFloat("destroyvehicletask") + 25);
            taskRewardPanel.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("level") > PlayerPrefs.GetFloat("leveltask"))
        {
            level++;
            PlayerPrefs.SetFloat("leveltask", PlayerPrefs.GetFloat("leveltask") + 10);
            taskRewardPanel.SetActive(true);
        }
        killCount.text = PlayerPrefs.GetFloat("killcount") + "/" + PlayerPrefs.GetFloat("killtask");
        destroyVehicleCount.text = PlayerPrefs.GetFloat("destroyvehiclecount") + "/" + PlayerPrefs.GetFloat("destroyvehicletask");
        levelCount.text = PlayerPrefs.GetFloat("level") + "/" + PlayerPrefs.GetFloat("leveltask");
    }

    public void TaskReward()
    {
        PlayerPrefs.SetFloat("money" , PlayerPrefs.GetFloat("money") + ((kill * 300) + (vehicle * 300) + (level * 300)));
        kill = 0;
        vehicle = 0;
        level = 0;
        taskRewardPanel.SetActive(false);
    }

    public void CloseTaskRewardPanel()
    {
        kill = 0;
        vehicle = 0;
        level = 0;
        taskRewardPanel.SetActive(false);
    }
}
