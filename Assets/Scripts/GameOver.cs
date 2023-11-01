using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    GameObject[] enemies;
    public GameObject endGamePanel;
    public CastleHealth[] castleHealth;

    public TextMeshProUGUI killCount;
    public TextMeshProUGUI destroyVehicleCount;
    public TextMeshProUGUI levelCount;

    public GameObject restartButton;
    public GameObject nextLevelButton;
    public GameObject complatedLevelText;
    public GameObject failureLevelText;

    private bool is_time_stoped;
    private bool is_player_win;

    public GameObject[] balistas;

    public void Start()
    {
        is_time_stoped = false;
        PlayerPrefs.SetFloat("killcountlevel" , 0);
        PlayerPrefs.SetFloat("destroyvehiclecountlevel" , 0);
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        
            if (enemies.Length == 0)
            {
                if (!is_time_stoped)
                {
                    endGamePanel.SetActive(true);

                    nextLevelButton.SetActive(true);
                    restartButton.SetActive(false);
                    complatedLevelText.SetActive(true);
                    failureLevelText.SetActive(false);

                    killCount.text = PlayerPrefs.GetFloat("killcountlevel").ToString();
                    destroyVehicleCount.text = PlayerPrefs.GetFloat("destroyvehiclecountlevel").ToString();
                    levelCount.text = PlayerPrefs.GetFloat("level").ToString();

                    PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + 500);

                    //Time.timeScale = 0f;
                    is_time_stoped = true;
                    is_player_win = true;

                for (int i = 0; i < balistas.Length; i++)
                {
                    balistas[i].SetActive(false);
                }
            }
                
            }
            for (int i = 0; i < castleHealth.Length; i++)
            {
                if (!is_time_stoped)
                {
                    if (castleHealth[i].castleHealth <= 0)
                    {
                        endGamePanel.SetActive(true);

                        nextLevelButton.SetActive(false);
                        restartButton.SetActive(true);
                        complatedLevelText.SetActive(false);
                        failureLevelText.SetActive(true);

                        killCount.text = PlayerPrefs.GetFloat("killcountlevel").ToString();
                        destroyVehicleCount.text = PlayerPrefs.GetFloat("destroyvehiclecountlevel").ToString();
                        levelCount.text = PlayerPrefs.GetFloat("level").ToString();

                        //Time.timeScale = 0f;
                        is_time_stoped = true;
                        for (int j = 0; j   < balistas.Length; j++)
                        {
                            balistas[j].SetActive(false);
                        }

                    }
                }      
            }

        
    }

    public void MainMenu()
    {
        if (is_player_win)
        {
            PlayerPrefs.SetFloat("level", PlayerPrefs.GetFloat("level") + 1);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetFloat("level" , PlayerPrefs.GetFloat("level") + 1);
        SceneManager.LoadScene("SampleScene");
    }
}
