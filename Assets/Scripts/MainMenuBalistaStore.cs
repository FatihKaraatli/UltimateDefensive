using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuBalistaStore : MonoBehaviour
{
    public GameObject[] balistaGameobjects;
    public GameObject[] balistaBuyButton;
    public GameObject[] balistaChooseButton;
    public GameObject[] balistaPrices;

    public TextMeshProUGUI[] balistaPowersText;
    public TextMeshProUGUI[] balistaPowerPricesText;
    public GameObject[] balistaPowerButtons;
    public GameObject[] balistaPowerMoneyIcons;

    public GameObject tick;

    private int index = 0;
    private int currentBalistaIndex;

    public TextMeshProUGUI moneyText;

    public AudioClip buySound;
    public AudioClip chooseSound;
    public AudioClip UpgradeSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("firstImplamentbalistapower") == 0)
        {
            PlayerPrefs.SetFloat("firstbalistapower", 5);
            PlayerPrefs.SetFloat("firstbalistapowermoney", 100);

            PlayerPrefs.SetFloat("secondbalistapower", 25);
            PlayerPrefs.SetFloat("secondbalistapowermoney", 500);

            PlayerPrefs.SetFloat("thirdbalistapower", 50);
            PlayerPrefs.SetFloat("thirdbalistapowermoney", 500);

            PlayerPrefs.SetFloat("fourthbalistapower", 75);
            PlayerPrefs.SetFloat("fourthbalistapowermoney", 500);

            PlayerPrefs.SetFloat("fifthbalistapower", 100);
            PlayerPrefs.SetFloat("fifthbalistapowermoney", 500);

            PlayerPrefs.SetFloat("firstImplamentbalistapower", 1);

        }

        //PlayerPrefs.SetFloat("money", 999999);

        currentBalistaIndex = PlayerPrefs.GetInt("currentbalistaindex");
        index = currentBalistaIndex;
        Tick(PlayerPrefs.GetInt("currentbalistaindex"));


        if (PlayerPrefs.GetInt("currentbalistaindex") == 0)
        {
            tick.SetActive(true);

            PlayerPrefs.SetString("buyfirstbalista", "true");
            for (int i = 0; i < balistaGameobjects.Length; i++)
            {
                if (i == 0)
                {
                    balistaPrices[i].SetActive(false);
                    balistaBuyButton[i].SetActive(false);
                    balistaChooseButton[i].SetActive(true);
                    balistaGameobjects[i].SetActive(true);

                    balistaPowerPricesText[i].enabled = true;
                    balistaPowerButtons[i].SetActive(true);
                    balistaPowersText[i].enabled = true;
                    balistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    balistaPrices[i].SetActive(false);
                    balistaBuyButton[i].SetActive(false);
                    balistaChooseButton[i].SetActive(false);
                    balistaGameobjects[i].SetActive(false);

                    balistaPowerPricesText[i].enabled = false;
                    balistaPowerButtons[i].SetActive(false);
                    balistaPowersText[i].enabled = false;
                    balistaPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < balistaGameobjects.Length; i++)
            {
                if (i == currentBalistaIndex)
                {
                    balistaPrices[i].SetActive(false);
                    balistaBuyButton[i].SetActive(false);
                    balistaChooseButton[i].SetActive(true);
                    balistaGameobjects[i].SetActive(true);

                    balistaPowerPricesText[i].enabled = true;
                    balistaPowerButtons[i].SetActive(true);
                    balistaPowersText[i].enabled = true;
                    balistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    balistaPrices[i].SetActive(false);
                    balistaBuyButton[i].SetActive(false);
                    balistaChooseButton[i].SetActive(false);
                    balistaGameobjects[i].SetActive(false);

                    balistaPowerPricesText[i].enabled = false;
                    balistaPowerButtons[i].SetActive(false);
                    balistaPowersText[i].enabled = false;
                    balistaPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
    }

    
    void Update()
    {
        moneyText.text = PlayerPrefs.GetFloat("money").ToString();

        if (index == 0)
        {
            Is_Bought("buyfirstbalista", 0);
            balistaPowersText[0].text = "POWER : " + PlayerPrefs.GetFloat("firstbalistapower");
            balistaPowerPricesText[0].text = PlayerPrefs.GetFloat("firstbalistapowermoney").ToString(); 
            balistaPowersText[0].enabled = true;
        }
        else if (index == 1)
        {
            Is_Bought("buysecondbalista", 1);
            balistaPowersText[1].text = "POWER : " + PlayerPrefs.GetFloat("secondbalistapower");
            balistaPowerPricesText[1].text = PlayerPrefs.GetFloat("secondbalistapowermoney").ToString();
            balistaPowersText[1].enabled = true;
        }
        else if (index == 2)
        {
            Is_Bought("buythirdbalista", 2);
            balistaPowersText[2].text = "POWER : " + PlayerPrefs.GetFloat("thirdbalistapower");
            balistaPowerPricesText[2].text = PlayerPrefs.GetFloat("thirdbalistapowermoney").ToString();
            balistaPowersText[2].enabled = true;
        }
        else if (index == 3)
        {
            Is_Bought("buyfourthbalista", 3);
            balistaPowersText[3].text = "POWER : " + PlayerPrefs.GetFloat("fourthbalistapower");
            balistaPowerPricesText[3].text = PlayerPrefs.GetFloat("fourthbalistapowermoney").ToString();
            balistaPowersText[3].enabled = true;
        }
        else if (index == 4)
        {
            Is_Bought("buyfifthbalista", 4);
            balistaPowersText[4].text = "POWER : " + PlayerPrefs.GetFloat("fifthbalistapower");
            balistaPowerPricesText[4].text = PlayerPrefs.GetFloat("fifthbalistapowermoney").ToString();
            balistaPowersText[4].enabled = true;
        }
    }

    public void FirstBalistaBuyButton()
    {

    }
    public void SecondBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 2000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 2000);
            PlayerPrefs.SetInt("currentbalistaindex", 1);
            PlayerPrefs.SetString("buysecondbalista", "true");
            Tick(1);
        }
        Is_Bought("buysecondbalista", 1);
    }
    public void ThirdBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 5000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 5000);
            PlayerPrefs.SetInt("currentbalistaindex", 2);
            PlayerPrefs.SetString("buythirdbalista", "true");
            Tick(2);
        }
        Is_Bought("buythirdbalista", 2);
    }
    public void FourthBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 12000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 12000);
            PlayerPrefs.SetInt("currentbalistaindex", 3);
            PlayerPrefs.SetString("buyfourthbalista", "true");
            Tick(3);
        }
        Is_Bought("buyfourthbalista", 3);
    }
    public void FifthBalistaBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 20000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 20000);
            PlayerPrefs.SetInt("currentbalistaindex", 4);
            PlayerPrefs.SetString("buyfifthbalista", "true");
            Tick(4);
        }
        Is_Bought("buyfifthbalista", 4);
    }



    public void FirstBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currentbalistaindex", 0);
        audioSource.PlayOneShot(chooseSound);
        Tick(0);
    }
    public void SecondBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currentbalistaindex", 1);
        audioSource.PlayOneShot(chooseSound);
        Tick(1);
    }
    public void ThirdBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currentbalistaindex", 2);
        audioSource.PlayOneShot(chooseSound);
        Tick(2);
    }
    public void FourthBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currentbalistaindex", 3);
        audioSource.PlayOneShot(chooseSound);
        Tick(3);
    }
    public void FifthBalistaChooseButton()
    {
        PlayerPrefs.SetInt("currentbalistaindex", 4);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirstbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirstbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthbalista", i);
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
            for (int i = 0; i < balistaBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthbalista", i);
                    Tick(4);
                }
                else
                {
                    Not_Bought(i);
                }
            }
        }
    }



    private void Is_Bought(string str , int i)
    {
        if (PlayerPrefs.GetString(str) == "true")
        {
            balistaPrices[i].SetActive(false);
            balistaBuyButton[i].SetActive(false);
            balistaChooseButton[i].SetActive(true);
            balistaGameobjects[i].SetActive(true);

            balistaPowersText[i].enabled = true;
            balistaPowerPricesText[i].enabled = true;
            balistaPowerButtons[i].SetActive(true);
            balistaPowerMoneyIcons[i].SetActive(true);
        }
        else
        {
            balistaPrices[i].SetActive(true);
            balistaBuyButton[i].SetActive(true);
            balistaChooseButton[i].SetActive(false);
            balistaGameobjects[i].SetActive(true);

            balistaPowersText[i].enabled = false;
            balistaPowerPricesText[i].enabled = false;
            balistaPowerButtons[i].SetActive(false);
            balistaPowerMoneyIcons[i].SetActive(false);
        } 
    }

    private void Not_Bought(int i)
    {
        balistaPrices[i].SetActive(false);
        balistaBuyButton[i].SetActive(false);
        balistaChooseButton[i].SetActive(false);
        balistaGameobjects[i].SetActive(false);

        balistaPowersText[i].enabled = false;
        balistaPowerPricesText[i].enabled = false;
        balistaPowerButtons[i].SetActive(false);
        balistaPowerMoneyIcons[i].SetActive(false);
    }

    private void Tick(int i)
    {
        if (PlayerPrefs.GetInt("currentbalistaindex") == i)
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
        if (PlayerPrefs.GetInt("currentbalistaindex") == 0 && index == 0)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("firstbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("firstbalistapowermoney"));
                PlayerPrefs.SetFloat("firstbalistapower", PlayerPrefs.GetFloat("firstbalistapower") + 1);
                PlayerPrefs.SetFloat("firstbalistapowermoney", PlayerPrefs.GetFloat("firstbalistapowermoney") + 50);
                balistaPowersText[0].text = "POWER : " + PlayerPrefs.GetFloat("firstbalistapower");
                balistaPowerPricesText[0].text = PlayerPrefs.GetFloat("firstbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentbalistaindex") == 1 && index == 1)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("secondbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("secondbalistapowermoney"));
                PlayerPrefs.SetFloat("secondbalistapower", PlayerPrefs.GetFloat("secondbalistapower") + 1);
                PlayerPrefs.SetFloat("secondbalistapowermoney", PlayerPrefs.GetFloat("secondbalistapowermoney") + 50);
                balistaPowersText[1].text = "POWER : " + PlayerPrefs.GetFloat("secondbalistapower");
                balistaPowerPricesText[1].text = PlayerPrefs.GetFloat("secondbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentbalistaindex") == 2 && index == 2)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("thirdbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("thirdbalistapowermoney"));
                PlayerPrefs.SetFloat("thirdbalistapower", PlayerPrefs.GetFloat("thirdbalistapower") + 1);
                PlayerPrefs.SetFloat("thirdbalistapowermoney", PlayerPrefs.GetFloat("thirdbalistapowermoney") + 50);
                balistaPowersText[2].text = "POWER : " + PlayerPrefs.GetFloat("thirdbalistapower");
                balistaPowerPricesText[2].text = PlayerPrefs.GetFloat("thirdbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentbalistaindex") == 3 && index == 3)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fourthbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fourthbalistapowermoney"));
                PlayerPrefs.SetFloat("fourthbalistapower", PlayerPrefs.GetFloat("fourthbalistapower") + 1);
                PlayerPrefs.SetFloat("fourthbalistapowermoney", PlayerPrefs.GetFloat("fourthbalistapowermoney") + 50);
                balistaPowersText[3].text = "POWER : " + PlayerPrefs.GetFloat("fourthbalistapower");
                balistaPowerPricesText[3].text = PlayerPrefs.GetFloat("fourthbalistapowermoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentbalistaindex") == 4 && index == 4)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fifthbalistapowermoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fifthbalistapowermoney"));
                PlayerPrefs.SetFloat("fifthbalistapower", PlayerPrefs.GetFloat("fifthbalistapower") + 1);
                PlayerPrefs.SetFloat("fifthbalistapowermoney", PlayerPrefs.GetFloat("fifthbalistapowermoney") + 50);
                balistaPowersText[4].text = "POWER : " + PlayerPrefs.GetFloat("fifthbalistapower");
                balistaPowerPricesText[4].text = PlayerPrefs.GetFloat("fifthbalistapowermoney").ToString();
            }
        }
    }

    public int GetIndex()
    {
        return index;
    }
}
