using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuTowerBalistaStore : MonoBehaviour
{
    public GameObject[] towerbalistaGameobjects;
    public GameObject[] towerbalistaBuyButton;
    public GameObject[] towerbalistaChooseButton;
    public GameObject[] towerbalistaPrices;

    public TextMeshProUGUI[] towerbalistaPowersText;
    public TextMeshProUGUI[] towerbalistaPowerPricesText;
    public GameObject[] towerbalistaPowerButtons;
    public GameObject[] towerbalistaPowerMoneyIcons;

    public GameObject tick;

    private int index = 0;
    private int currentTowerBalistaIndex;

    public TextMeshProUGUI moneyText;

    public AudioClip buySound;
    public AudioClip chooseSound;
    public AudioClip UpgradeSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("firstImplamenttowerbalistapower") == 0)
        {
            PlayerPrefs.SetFloat("firsttowerbalistapower", 2);
            PlayerPrefs.SetFloat("firsttowerbalistapowermoney", 200);

            PlayerPrefs.SetFloat("secondtowerbalistapower", 10);
            PlayerPrefs.SetFloat("secondtowerbalistapowermoney", 500);

            PlayerPrefs.SetFloat("thirdtowerbalistapower", 20);
            PlayerPrefs.SetFloat("thirdtowerbalistapowermoney", 500);

            PlayerPrefs.SetFloat("fourthtowerbalistapower", 35);
            PlayerPrefs.SetFloat("fourthtowerbalistapowermoney", 500);

            PlayerPrefs.SetFloat("fifthtowerbalistapower", 55);
            PlayerPrefs.SetFloat("fifthtowerbalistapowermoney", 500);

            PlayerPrefs.SetFloat("firstImplamenttowerbalistapower", 1);

        }


        currentTowerBalistaIndex = PlayerPrefs.GetInt("currenttowerbalistaindex");
        index = currentTowerBalistaIndex;
        Tick(PlayerPrefs.GetInt("currenttowerbalistaindex"));

        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 0)
        {
            tick.SetActive(true);
            PlayerPrefs.SetString("buyfirsttowerbalista", "true");
            for (int i = 0; i < towerbalistaGameobjects.Length; i++)
            {
                if (i == 0)
                {
                    towerbalistaPrices[i].SetActive(false);
                    towerbalistaBuyButton[i].SetActive(false);
                    towerbalistaChooseButton[i].SetActive(true);
                    towerbalistaGameobjects[i].SetActive(true);

                    towerbalistaPowerPricesText[i].enabled = true;
                    towerbalistaPowerButtons[i].SetActive(true);
                    towerbalistaPowersText[i].enabled = true;
                    towerbalistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    towerbalistaPrices[i].SetActive(false);
                    towerbalistaBuyButton[i].SetActive(false);
                    towerbalistaChooseButton[i].SetActive(false);
                    towerbalistaGameobjects[i].SetActive(false);

                    towerbalistaPowerPricesText[i].enabled = false;
                    towerbalistaPowerButtons[i].SetActive(false);
                    towerbalistaPowersText[i].enabled = false;
                    towerbalistaPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < towerbalistaGameobjects.Length; i++)
            {
                if (i == currentTowerBalistaIndex)
                {
                    towerbalistaPrices[i].SetActive(false);
                    towerbalistaBuyButton[i].SetActive(false);
                    towerbalistaChooseButton[i].SetActive(true);
                    towerbalistaGameobjects[i].SetActive(true);

                    towerbalistaPowerPricesText[i].enabled = true;
                    towerbalistaPowerButtons[i].SetActive(true);
                    towerbalistaPowersText[i].enabled = true;
                    towerbalistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    towerbalistaPrices[i].SetActive(false);
                    towerbalistaBuyButton[i].SetActive(false);
                    towerbalistaChooseButton[i].SetActive(false);
                    towerbalistaGameobjects[i].SetActive(false);

                    towerbalistaPowerPricesText[i].enabled = false;
                    towerbalistaPowerButtons[i].SetActive(false);
                    towerbalistaPowersText[i].enabled = false;
                    towerbalistaPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
    }

    void Update()
    {
        moneyText.text = PlayerPrefs.GetFloat("money").ToString();

        if (index == 0)
        {
            Is_Bought("buyfirsttowerbalista", 0);
            towerbalistaPowersText[0].text = "POWER : " + PlayerPrefs.GetFloat("firsttowerbalistapower");
            towerbalistaPowerPricesText[0].text = PlayerPrefs.GetFloat("firsttowerbalistapowermoney").ToString();
            towerbalistaPowersText[0].enabled = true;
        }
        else if (index == 1)
        {
            Is_Bought("buysecondtowerbalista", 1);
            towerbalistaPowersText[1].text = "POWER : " + PlayerPrefs.GetFloat("secondtowerbalistapower");
            towerbalistaPowerPricesText[1].text = PlayerPrefs.GetFloat("secondtowerbalistapowermoney").ToString();
            towerbalistaPowersText[1].enabled = true;
        }
        else if (index == 2)
        {
            Is_Bought("buythirdtowerbalista", 2);
            towerbalistaPowersText[2].text = "POWER : " + PlayerPrefs.GetFloat("thirdtowerbalistapower");
            towerbalistaPowerPricesText[2].text = PlayerPrefs.GetFloat("thirdtowerbalistapowermoney").ToString();
            towerbalistaPowersText[2].enabled = true;
        }
        else if (index == 3)
        {
            Is_Bought("buyfourthtowerbalista", 3);
            towerbalistaPowersText[3].text = "POWER : " + PlayerPrefs.GetFloat("fourthtowerbalistapower");
            towerbalistaPowerPricesText[3].text = PlayerPrefs.GetFloat("fourthtowerbalistapowermoney").ToString();
            towerbalistaPowersText[3].enabled = true;
        }
        else if (index == 4)
        {
            Is_Bought("buyfifthtowerbalista", 4);
            towerbalistaPowersText[4].text = "POWER : " + PlayerPrefs.GetFloat("fifthtowerbalistapower");
            towerbalistaPowerPricesText[4].text = PlayerPrefs.GetFloat("fifthtowerbalistapowermoney").ToString();
            towerbalistaPowersText[4].enabled = true;
        }
    }

    public void FirstTowerBalistaBuyButton()
    {

    }
    public void SecondTowerBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 2500)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 2500);
            PlayerPrefs.SetInt("currenttowerbalistaindex", 1);
            PlayerPrefs.SetString("buysecondtowerbalista", "true");
            Tick(1);
        }
        Is_Bought("buysecondtowerbalista", 1);
    }
    public void ThirdTowerBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 5000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 5000);
            PlayerPrefs.SetInt("currenttowerbalistaindex", 2);
            PlayerPrefs.SetString("buythirdtowerbalista", "true");
            Tick(2);
        }
        Is_Bought("buythirdtowerbalista", 2);
    }
    public void FourthTowerBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 12000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 12000);
            PlayerPrefs.SetInt("currenttowerbalistaindex", 3);
            PlayerPrefs.SetString("buyfourthtowerbalista", "true");
            Tick(3);
        }
        Is_Bought("buyfourthtowerbalista", 3);
    }
    public void FifthTowerBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 20000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 20000);
            PlayerPrefs.SetInt("currenttowerbalistaindex", 4);
            PlayerPrefs.SetString("buyfifthtowerbalista", "true");
            Tick(4);
        }
        Is_Bought("buyfifthtowerbalista", 4);
    }



    public void FirstTowerBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerbalistaindex", 0);
        audioSource.PlayOneShot(chooseSound);
        Tick(0);
    }
    public void SecondTowerBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerbalistaindex", 1);
        audioSource.PlayOneShot(chooseSound);
        Tick(1);
    }
    public void ThirdTowerBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerbalistaindex", 2);
        audioSource.PlayOneShot(chooseSound);
        Tick(2);
    }
    public void FourthTowerBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerbalistaindex", 3);
        audioSource.PlayOneShot(chooseSound);
        Tick(3);
    }
    public void FifthTowerBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currenttowerbalistaindex", 4);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirsttowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondtowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdtowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthtowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthtowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirsttowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondtowerbalista", i);
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
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdtowerbalista", i);
                    Tick(2);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }else if (index == 3)
        {
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthtowerbalista", i);
                    Tick(3);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }else if (index == 4)
        {
            for (int i = 0; i < towerbalistaBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthtowerbalista", i);
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
            towerbalistaPrices[i].SetActive(false);
            towerbalistaBuyButton[i].SetActive(false);
            towerbalistaChooseButton[i].SetActive(true);
            towerbalistaGameobjects[i].SetActive(true);

            towerbalistaPowersText[i].enabled = true;
            towerbalistaPowerPricesText[i].enabled = true;
            towerbalistaPowerButtons[i].SetActive(true);
            towerbalistaPowerMoneyIcons[i].SetActive(true);
        }
        else
        {
            towerbalistaPrices[i].SetActive(true);
            towerbalistaBuyButton[i].SetActive(true);
            towerbalistaChooseButton[i].SetActive(false);
            towerbalistaGameobjects[i].SetActive(true);

            towerbalistaPowersText[i].enabled = false;
            towerbalistaPowerPricesText[i].enabled = false;
            towerbalistaPowerButtons[i].SetActive(false);
            towerbalistaPowerMoneyIcons[i].SetActive(false);
        }
    }

    private void Not_Bought(int i)
    {
        towerbalistaPrices[i].SetActive(false);
        towerbalistaBuyButton[i].SetActive(false);
        towerbalistaChooseButton[i].SetActive(false);
        towerbalistaGameobjects[i].SetActive(false);

        towerbalistaPowersText[i].enabled = false;
        towerbalistaPowerPricesText[i].enabled = false;
        towerbalistaPowerButtons[i].SetActive(false);
        towerbalistaPowerMoneyIcons[i].SetActive(false);
    }

    private void Tick(int i)
    {
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == i)
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
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 0 && index == 0)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("firsttowerbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("firsttowerbalistapowermoney"));
                PlayerPrefs.SetFloat("firsttowerbalistapower", PlayerPrefs.GetFloat("firsttowerbalistapower") + 1);
                PlayerPrefs.SetFloat("firsttowerbalistapowermoney", PlayerPrefs.GetFloat("firsttowerbalistapowermoney") + 50);
                towerbalistaPowersText[0].text = "POWER : " + PlayerPrefs.GetFloat("firsttowerbalistapower");
                towerbalistaPowerPricesText[0].text = PlayerPrefs.GetFloat("firsttowerbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 1 && index == 1)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("secondtowerbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("secondtowerbalistapowermoney"));
                PlayerPrefs.SetFloat("secondtowerbalistapower", PlayerPrefs.GetFloat("secondtowerbalistapower") + 1);
                PlayerPrefs.SetFloat("secondtowerbalistapowermoney", PlayerPrefs.GetFloat("secondtowerbalistapowermoney") + 50);
                towerbalistaPowersText[1].text = "POWER : " + PlayerPrefs.GetFloat("secondtowerbalistapower");
                towerbalistaPowerPricesText[1].text = PlayerPrefs.GetFloat("secondtowerbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 2 && index == 2)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("thirdtowerbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("thirdtowerbalistapowermoney"));
                PlayerPrefs.SetFloat("thirdtowerbalistapower", PlayerPrefs.GetFloat("thirdtowerbalistapower") + 1);
                PlayerPrefs.SetFloat("thirdtowerbalistapowermoney", PlayerPrefs.GetFloat("thirdtowerbalistapowermoney") + 50);
                towerbalistaPowersText[2].text = "POWER : " + PlayerPrefs.GetFloat("thirdtowerbalistapower");
                towerbalistaPowerPricesText[2].text = PlayerPrefs.GetFloat("thirdtowerbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 3 && index == 3)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fourthtowerbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fourthtowerbalistapowermoney"));
                PlayerPrefs.SetFloat("fourthtowerbalistapower", PlayerPrefs.GetFloat("fourthtowerbalistapower") + 1);
                PlayerPrefs.SetFloat("fourthtowerbalistapowermoney", PlayerPrefs.GetFloat("fourthtowerbalistapowermoney") + 50);
                towerbalistaPowersText[3].text = "POWER : " + PlayerPrefs.GetFloat("fourthtowerbalistapower");
                towerbalistaPowerPricesText[3].text = PlayerPrefs.GetFloat("fourthtowerbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currenttowerbalistaindex") == 4 && index == 4)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fifthtowerbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fifthtowerbalistapowermoney"));
                PlayerPrefs.SetFloat("fifthtowerbalistapower", PlayerPrefs.GetFloat("fifthtowerbalistapower") + 1);
                PlayerPrefs.SetFloat("fifthtowerbalistapowermoney", PlayerPrefs.GetFloat("fifthtowerbalistapowermoney") + 50);
                towerbalistaPowersText[4].text = "POWER : " + PlayerPrefs.GetFloat("fifthtowerbalistapower");
                towerbalistaPowerPricesText[4].text = PlayerPrefs.GetFloat("fifthtowerbalistapowermoney").ToString();
            }
        }
    }



}
