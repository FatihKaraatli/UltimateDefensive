using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuTowerStore : MonoBehaviour
{
    public GameObject[] towerGameobjects;
    public GameObject[] towerBuyButton;
    public GameObject[] towerChooseButton;
    public GameObject[] towerPrices;

    public TextMeshProUGUI[] towerHealthText;
    public TextMeshProUGUI[] towerHealthPricesText;
    public GameObject[] towerHealthButtons;
    public GameObject[] towerPowerMoneyIcons;

    public GameObject tick;

    private int index = 0;
    private int currentTowerIndex;

    public TextMeshProUGUI moneyText;

    public AudioClip buySound;
    public AudioClip chooseSound;
    public AudioClip UpgradeSound;

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("firstImplamenttowerhealth") == 0)
        {
            PlayerPrefs.SetFloat("firsttowerhealth", 300);
            PlayerPrefs.SetFloat("firsttowerhealthmoney", 500);

            PlayerPrefs.SetFloat("secondtowerhealth", 500);
            PlayerPrefs.SetFloat("secondtowerhealthmoney", 500);

            PlayerPrefs.SetFloat("thirdtowerhealth", 800);
            PlayerPrefs.SetFloat("thirdtowerhealthmoney", 500);

            PlayerPrefs.SetFloat("fourthtowerhealth", 1500);
            PlayerPrefs.SetFloat("fourthtowerhealthmoney", 500);

            PlayerPrefs.SetFloat("fifthtowerhealth", 2500);
            PlayerPrefs.SetFloat("fifthtowerhealthmoney", 500);

            PlayerPrefs.SetFloat("firstImplamenttowerhealth", 1);

        }

        currentTowerIndex = PlayerPrefs.GetInt("currenttowerindex");
        index = currentTowerIndex;
        Tick(PlayerPrefs.GetInt("currenttowerindex"));

        if (PlayerPrefs.GetInt("currenttowerindex") == 0)
        {
            tick.SetActive(true);
            PlayerPrefs.SetString("buyfirsttower", "true");
            for (int i = 0; i < towerGameobjects.Length; i++)
            {
                if (i == 0)
                {
                    towerPrices[i].SetActive(false);
                    towerBuyButton[i].SetActive(false);
                    towerChooseButton[i].SetActive(true);
                    towerGameobjects[i].SetActive(true);

                    towerHealthPricesText[i].enabled = true;
                    towerHealthButtons[i].SetActive(true);
                    towerHealthText[i].enabled = true;
                    towerPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    towerPrices[i].SetActive(false);
                    towerBuyButton[i].SetActive(false);
                    towerChooseButton[i].SetActive(false);
                    towerGameobjects[i].SetActive(false);

                    towerHealthPricesText[i].enabled = false;
                    towerHealthButtons[i].SetActive(false);
                    towerHealthText[i].enabled = false;
                    towerPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < towerGameobjects.Length; i++)
            {
                if (i == currentTowerIndex)
                {
                    towerPrices[i].SetActive(false);
                    towerBuyButton[i].SetActive(false);
                    towerChooseButton[i].SetActive(true);
                    towerGameobjects[i].SetActive(true);

                    towerHealthPricesText[i].enabled = true;
                    towerHealthButtons[i].SetActive(true);
                    towerHealthText[i].enabled = true;
                    towerPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    towerPrices[i].SetActive(false);
                    towerBuyButton[i].SetActive(false);
                    towerChooseButton[i].SetActive(false);
                    towerGameobjects[i].SetActive(false);

                    towerHealthPricesText[i].enabled = false;
                    towerHealthButtons[i].SetActive(false);
                    towerHealthText[i].enabled = false;
                    towerPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        moneyText.text = PlayerPrefs.GetFloat("money").ToString();

        if (index == 0)
        {
            Is_Bought("buyfirsttower", 0);
            towerHealthText[0].text = "HEALTH : " + PlayerPrefs.GetFloat("firsttowerhealth");
            towerHealthPricesText[0].text = PlayerPrefs.GetFloat("firsttowerhealthmoney").ToString();
            towerHealthText[0].enabled = true;
        }
        else if (index == 1)
        {
            Is_Bought("buysecondtower", 1);
            towerHealthText[1].text = "HEALTH : " + PlayerPrefs.GetFloat("secondtowerhealth");
            towerHealthPricesText[1].text = PlayerPrefs.GetFloat("secondtowerhealthmoney").ToString();
            towerHealthText[1].enabled = true;
        }
        else if (index == 2)
        {
            Is_Bought("buythirdtower", 2);
            towerHealthText[2].text = "HEALTH : " + PlayerPrefs.GetFloat("thirdtowerhealth");
            towerHealthPricesText[2].text = PlayerPrefs.GetFloat("thirdtowerhealthmoney").ToString();
            towerHealthText[2].enabled = true;
        }
        else if (index == 3)
        {
            Is_Bought("buyfourthtower", 3);
            towerHealthText[3].text = "HEALTH : " + PlayerPrefs.GetFloat("fourthtowerhealth");
            towerHealthPricesText[3].text = PlayerPrefs.GetFloat("fourthtowerhealthmoney").ToString();
            towerHealthText[3].enabled = true;
        }
        else if (index == 4)
        {
            Is_Bought("buyfifthtower", 4);
            towerHealthText[4].text = "HEALTH : " + PlayerPrefs.GetFloat("fifthtowerhealth");
            towerHealthPricesText[4].text = PlayerPrefs.GetFloat("fifthtowerhealthmoney").ToString();
            towerHealthText[4].enabled = true;
        }
    }


    public void FirstTowerBuyButton()
    {

    }
    public void SecondTowerBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 2500)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 2500);
            PlayerPrefs.SetInt("currenttowerindex", 1);
            PlayerPrefs.SetString("buysecondtower", "true");
            Tick(1);
        }
        Is_Bought("buysecondtower", 1);
    }
    public void ThirdTowerBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 7500)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 7500);
            PlayerPrefs.SetInt("currenttowerindex", 2);
            PlayerPrefs.SetString("buythirdtower", "true");
            Tick(2);
        }
        Is_Bought("buythirdtower", 2);
    }
    public void FourthTowerBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 15000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 15000);
            PlayerPrefs.SetInt("currenttowerindex", 3);
            PlayerPrefs.SetString("buyfourthtower", "true");
            Tick(3);
        }
        Is_Bought("buyfourthtower", 3);
    }
    public void FifthTowerBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 20000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 20000);
            PlayerPrefs.SetInt("currenttowerindex", 4);
            PlayerPrefs.SetString("buyfifthtower", "true");
            Tick(4);
        }
        Is_Bought("buyfifthtower", 4);
    }



    public void FirstTowerChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerindex", 0);
        audioSource.PlayOneShot(chooseSound);
        Tick(0);
    }
    public void SecondTowerChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerindex", 1);
        audioSource.PlayOneShot(chooseSound);
        Tick(1);
    }
    public void ThirdTowerChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerindex", 2);
        audioSource.PlayOneShot(chooseSound);
        Tick(2);
    }
    public void FourthTowerChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerindex", 3);
        audioSource.PlayOneShot(chooseSound);
        Tick(3);
    }
    public void FifthTowerChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerindex", 4);
        audioSource.PlayOneShot(chooseSound);
        Tick(4);
    }


    public void RightButton()
    {
        index++;
        if (index > 4)
        {
            index = 0;
        }

        if (index == 0)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirsttower", i);
                    Tick(0);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondtower", i);
                    Tick(1);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdtower", i);
                    Tick(2);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthtower", i);
                    Tick(3);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 4)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthtower", i);
                    Tick(4);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }

    }

    public void LeftButton()
    {
        index--;
        if (index < 0)
        {
            index = 4;
        }

        if (index == 0)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirsttower", i);
                    Tick(0);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 1)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondtower", i);
                    Tick(1);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 2)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdtower", i);
                    Tick(2);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 3)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthtower", i);
                    Tick(3);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
        else if (index == 4)
        {
            for (int i = 0; i < towerBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthtower", i);
                    Tick(4);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
    }

    private void Is_Bought(string str, int i)
    {
        if (PlayerPrefs.GetString(str) == "true")
        {
            towerPrices[i].SetActive(false);
            towerBuyButton[i].SetActive(false);
            towerChooseButton[i].SetActive(true);
            towerGameobjects[i].SetActive(true);

            towerHealthPricesText[i].enabled = true;
            towerHealthButtons[i].SetActive(true);
            towerHealthText[i].enabled = true; 
            towerPowerMoneyIcons[i].SetActive(true);
        }
        else
        {
            towerPrices[i].SetActive(true);
            towerBuyButton[i].SetActive(true);
            towerChooseButton[i].SetActive(false);
            towerGameobjects[i].SetActive(true);

            towerHealthPricesText[i].enabled = false;
            towerHealthButtons[i].SetActive(false);
            towerHealthText[i].enabled = false;
            towerPowerMoneyIcons[i].SetActive(false);
        }
    }

    private void Not_Bought(int i)
    {
        towerPrices[i].SetActive(false);
        towerBuyButton[i].SetActive(false);
        towerChooseButton[i].SetActive(false);
        towerGameobjects[i].SetActive(false);

        towerHealthPricesText[i].enabled = false;
        towerHealthButtons[i].SetActive(false);
        towerHealthText[i].enabled = false;
        towerPowerMoneyIcons[i].SetActive(false);
    }

    private void Tick(int i)
    {
        if (PlayerPrefs.GetInt("currenttowerindex") == i)
        {
            tick.SetActive(true);
        }
        else
        {
            tick.SetActive(false);
        }
    }

    public void IncreasePower()
    {
        if (PlayerPrefs.GetInt("currenttowerindex") == 0 && index == 0)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("firsttowerhealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("firsttowerhealthmoney"));
                PlayerPrefs.SetFloat("firsttowerhealth", PlayerPrefs.GetFloat("firsttowerhealth") + 50);
                PlayerPrefs.SetFloat("firsttowerhealthmoney", PlayerPrefs.GetFloat("firsttowerhealthmoney") + 50);
                towerHealthText[0].text = "HEALTH : " + PlayerPrefs.GetFloat("firsttowerhealth");
                towerHealthPricesText[0].text = PlayerPrefs.GetFloat("firsttowerhealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerindex") == 1 && index == 1)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("secondtowerhealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("secondtowerhealthmoney"));
                PlayerPrefs.SetFloat("secondtowerhealth", PlayerPrefs.GetFloat("secondtowerhealth") + 50);
                PlayerPrefs.SetFloat("secondtowerhealthmoney", PlayerPrefs.GetFloat("secondtowerhealthmoney") + 50);
                towerHealthText[1].text = "HEALTH : " + PlayerPrefs.GetFloat("secondtowerhealth");
                towerHealthPricesText[1].text = PlayerPrefs.GetFloat("secondtowerhealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerindex") == 2 && index == 2)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("thirdtowerhealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("thirdtowerhealthmoney"));
                PlayerPrefs.SetFloat("thirdtowerhealth", PlayerPrefs.GetFloat("thirdtowerhealth") + 50);
                PlayerPrefs.SetFloat("thirdtowerhealthmoney", PlayerPrefs.GetFloat("thirdtowerhealthmoney") + 50);
                towerHealthText[2].text = "HEALTH : " + PlayerPrefs.GetFloat("thirdtowerhealth");
                towerHealthPricesText[2].text = PlayerPrefs.GetFloat("thirdtowerhealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerindex") == 3 && index == 3)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fourthtowerhealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fourthtowerhealthmoney"));
                PlayerPrefs.SetFloat("fourthtowerhealth", PlayerPrefs.GetFloat("fourthtowerhealth") + 50);
                PlayerPrefs.SetFloat("fourthtowerhealthmoney", PlayerPrefs.GetFloat("fourthtowerhealthmoney") + 50);
                towerHealthText[3].text = "HEALTH : " + PlayerPrefs.GetFloat("fourthtowerhealth");
                towerHealthPricesText[3].text = PlayerPrefs.GetFloat("fourthtowerhealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerindex") == 4 && index == 4)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fifthtowerhealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fifthtowerhealthmoney"));
                PlayerPrefs.SetFloat("fifthtowerhealth", PlayerPrefs.GetFloat("fifthtowerhealth") + 50);
                PlayerPrefs.SetFloat("fifthtowerhealthmoney", PlayerPrefs.GetFloat("fifthtowerhealthmoney") + 50);
                towerHealthText[4].text = "HEALTH : " + PlayerPrefs.GetFloat("fifthtowerhealth");
                towerHealthPricesText[4].text = PlayerPrefs.GetFloat("fifthtowerhealthmoney").ToString();
            }
        }
    }

}
