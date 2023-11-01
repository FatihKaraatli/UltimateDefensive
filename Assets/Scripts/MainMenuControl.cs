using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject balistaPanel;
    public GameObject castlePanel;
    public GameObject towerPanel;
    public GameObject settingsPanel;
    public GameObject taskPanel;
    public GameObject taskButton;
    
    public GameObject[] balistas;
    public GameObject[] castles;
    public GameObject[] towerbalistas;
    public GameObject[] towers;
    
    public GameObject[] environments;

    public GameObject backButton;
    public GameObject adsButton;

    public GameObject arrow;
    public GameObject cannon;
    public MainMenuBalistaStore balistaStore;


    public void Start()
    {
        PlayerPrefs.SetString("main", "null");

        for (int i = 0; i < balistas.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("currentbalistaindex"))
            {
                balistas[i].SetActive(true);
            }
            else
            {
                balistas[i].SetActive(false);
            }
        }
        
        for (int i = 0; i < castles.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("currentcastleindex"))
            {
                castles[i].SetActive(true);
            }
            else
            {
                castles[i].SetActive(false);
            }
        }
        
        for (int i = 0; i < towerbalistas.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("currenttowerbalistaindex"))
            {
                towerbalistas[i].SetActive(true);
            }
            else
            {
                towerbalistas[i].SetActive(false);
            }
        }
        
        for (int i = 0; i < towers.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("currenttowerindex"))
            {
                towers[i].SetActive(true);
            }
            else
            {
                towers[i].SetActive(false);
            }
        }


        if (PlayerPrefs.GetInt("environment") > 2)
        {
            PlayerPrefs.SetInt("environment" , 0);
        }
        for (int i = 0; i < environments.Length; i++)
        {
            if (i == PlayerPrefs.GetInt("environment"))
            {
                environments[i].SetActive(true);
            }
            else
            {
                environments[i].SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (PlayerPrefs.GetString("main") == "null")
        {
            mainPanel.SetActive(true);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(false);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(false);
            taskButton.SetActive(true);
            backButton.SetActive(false);
            //adsButton.SetActive(true);
        }
        else if (PlayerPrefs.GetString("main") == "balista")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(true);
            castlePanel.SetActive(false);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(false);
            taskButton.SetActive(false);
            backButton.SetActive(true);
            //adsButton.SetActive(false);
        }
        else if (PlayerPrefs.GetString("main") == "castle")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(true);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(false);
            taskButton.SetActive(false);
            backButton.SetActive(true);
            //adsButton.SetActive(false);
        }
        else if (PlayerPrefs.GetString("main") == "tower")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(false);
            towerPanel.SetActive(true);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(false);
            taskButton.SetActive(false);
            backButton.SetActive(true);
            //adsButton.SetActive(false);
        }
        else if (PlayerPrefs.GetString("main") == "settings")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(false);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(true);
            taskPanel.SetActive(false);
            taskButton.SetActive(false);
            backButton.SetActive(true);
            //adsButton.SetActive(false);

        }
        else if (PlayerPrefs.GetString("main") == "task")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(false);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(true);
            taskButton.SetActive(false);
            backButton.SetActive(true);
            //adsButton.SetActive(false);
        }
        else if (PlayerPrefs.GetString("main") == "empty")
        {
            mainPanel.SetActive(false);
            balistaPanel.SetActive(false);
            castlePanel.SetActive(false);
            towerPanel.SetActive(false);
            settingsPanel.SetActive(false);
            taskPanel.SetActive(false);
            taskButton.SetActive(false);
            backButton.SetActive(false);
            //adsButton.SetActive(false);
        }
    }


    public void Play()
    {
        EnvironmentChoose(PlayerPrefs.GetInt("environment"));
        PlayAnimation();
        Invoke("LoadScene" , 0.26f);
    }

    public void Settings()
    {
        settingsPanel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("main", "settings");
        LeanTween.scale(settingsPanel, new Vector3(1, 1, 1), 0.40f);
    }

    public void BalistaStore()
    {
        balistaPanel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("main", "balista");
        LeanTween.scale(balistaPanel, new Vector3(1, 1, 1), 0.40f);
    }
    
    public void CastleStore()
    {
        castlePanel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("main", "castle");
        LeanTween.scale(castlePanel, new Vector3(1, 1, 1), 0.40f);
    }
    
    public void TowerStore()
    {
        towerPanel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("main", "tower");
        LeanTween.scale(towerPanel, new Vector3(1, 1, 1), 0.40f);
    }

    public void Task()
    {
        PlayerPrefs.SetString("main", "task");
    }
    
    public void Back()
    {
        mainPanel.transform.localScale = new Vector3(0, 0, 0);
        PlayerPrefs.SetString("main", "null");
        LeanTween.scale(mainPanel, new Vector3(1, 1, 1), 0.40f);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void PlayAnimation()
    {
        if (balistaStore.GetIndex() == 4)
        {
            cannon.SetActive(true);
            LeanTween.scale(cannon, new Vector3(10, 10, 4f), 0.15f);
            LeanTween.moveLocal(cannon, new Vector3(2.48f, 17.51f, 6.13f), 0.25f);
        }
        else
        {
            arrow.SetActive(true);
            LeanTween.scale(arrow, new Vector3(3, 3, 4f), 0.15f);
            LeanTween.moveLocal(arrow, new Vector3(2.48f, 17.51f, 6.13f), 0.25f);
        }
        PlayerPrefs.SetString("main", "empty");
    }

    private void EnvironmentChoose(int index)
    {
        if (index > 2)
        {
            index = 0;
        }

        for (int i = 0; i < environments.Length; i++)
        {
            if (i == index)
            {
                environments[index].SetActive(true);
            }
            else
            {
                environments[i].SetActive(false);
            }
        }
    }
}
