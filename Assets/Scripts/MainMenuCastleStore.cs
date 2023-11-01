using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuCastleStore : MonoBehaviour
{
    public GameObject[] castleGameobjects;
    public GameObject[] castleBuyButton;
    public GameObject[] castleChooseButton;
    public GameObject[] castlePrices;

    public TextMeshProUGUI[] castleHealthText;
    public TextMeshProUGUI[] castleHealthPricesText;
    public GameObject[] castleHealthButtons;
    public GameObject[] balistaPowerMoneyIcons;

    public GameObject tick;

    private int index = 0;
    private int currentCastleIndex;

    public TextMeshProUGUI moneyText;

    public AudioClip buySound;
    public AudioClip chooseSound;
    public AudioClip UpgradeSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetFloat("firstImplamentcastlehealth") == 0)
        {
            PlayerPrefs.SetFloat("firstcastlehealth", 500);
            PlayerPrefs.SetFloat("firstcastlehealthmoney", 500);

            PlayerPrefs.SetFloat("secondcastlehealth", 1000);
            PlayerPrefs.SetFloat("secondcastlehealthmoney", 500);

            PlayerPrefs.SetFloat("thirdcastlehealth", 2000);
            PlayerPrefs.SetFloat("thirdcastlehealthmoney", 500);

            PlayerPrefs.SetFloat("fourthcastlehealth", 3000);
            PlayerPrefs.SetFloat("fourthcastlehealthmoney", 500);

            PlayerPrefs.SetFloat("fifthcastlehealth", 5000);
            PlayerPrefs.SetFloat("fifthcastlehealthmoney", 500);

            PlayerPrefs.SetFloat("firstImplamentcastlehealth", 1);

        }

        currentCastleIndex = PlayerPrefs.GetInt("currentcastleindex");
        index = currentCastleIndex;
        Tick(PlayerPrefs.GetInt("currentcastleindex"));

        if (PlayerPrefs.GetInt("currentcastleindex") == 0)
        {
            tick.SetActive(true);
            PlayerPrefs.SetString("buyfirstcastle", "true");
            for (int i = 0; i < castleGameobjects.Length; i++)
            {
                if (i == 0)
                {
                    castlePrices[i].SetActive(false);
                    castleBuyButton[i].SetActive(false);
                    castleChooseButton[i].SetActive(true);
                    castleGameobjects[i].SetActive(true);

                    castleHealthPricesText[i].enabled = true;
                    castleHealthButtons[i].SetActive(true);
                    castleHealthText[i].enabled = true;
                    balistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    castlePrices[i].SetActive(false);
                    castleBuyButton[i].SetActive(false);
                    castleChooseButton[i].SetActive(false);
                    castleGameobjects[i].SetActive(false);

                    castleHealthPricesText[i].enabled = false;
                    castleHealthButtons[i].SetActive(false);
                    castleHealthText[i].enabled = false;
                    balistaPowerMoneyIcons[i].SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < castleGameobjects.Length; i++)
            {
                if (i == currentCastleIndex)
                {
                    castlePrices[i].SetActive(false);
                    castleBuyButton[i].SetActive(false);
                    castleChooseButton[i].SetActive(true);
                    castleGameobjects[i].SetActive(true);

                    castleHealthPricesText[i].enabled = true;
                    castleHealthButtons[i].SetActive(true);
                    castleHealthText[i].enabled = true;
                    balistaPowerMoneyIcons[i].SetActive(true);
                }
                else
                {
                    castlePrices[i].SetActive(false);
                    castleBuyButton[i].SetActive(false);
                    castleChooseButton[i].SetActive(false);
                    castleGameobjects[i].SetActive(false);

                    castleHealthPricesText[i].enabled = false;
                    castleHealthButtons[i].SetActive(false);
                    castleHealthText[i].enabled = false;
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
            Is_Bought("buyfirstcastle", 0);
            castleHealthText[0].text = "HEALTH : " + PlayerPrefs.GetFloat("firstcastlehealth");
            castleHealthPricesText[0].text = PlayerPrefs.GetFloat("firstcastlehealthmoney").ToString();
            castleHealthText[0].enabled = true;
        }
        else if (index == 1)
        {
            Is_Bought("buysecondcastle", 1);
            castleHealthText[1].text = "HEALTH : " + PlayerPrefs.GetFloat("secondcastlehealth");
            castleHealthPricesText[1].text = PlayerPrefs.GetFloat("secondcastlehealthmoney").ToString();
            castleHealthText[1].enabled = true;
        }
        else if (index == 2)
        {
            Is_Bought("buythirdcastle", 2);
            castleHealthText[2].text = "HEALTH : " + PlayerPrefs.GetFloat("thirdcastlehealth");
            castleHealthPricesText[2].text = PlayerPrefs.GetFloat("thirdcastlehealthmoney").ToString();
            castleHealthText[2].enabled = true;
        }
        else if (index == 3)
        {
            Is_Bought("buyfourthcastle", 3);
            castleHealthText[3].text = "HEALTH : " + PlayerPrefs.GetFloat("fourthcastlehealth");
            castleHealthPricesText[3].text = PlayerPrefs.GetFloat("fourthcastlehealthmoney").ToString();
            castleHealthText[3].enabled = true;
        }
        else if (index == 4)
        {
            Is_Bought("buyfifthcastle", 4);
            castleHealthText[4].text = "HEALTH : " + PlayerPrefs.GetFloat("fifthcastlehealth");
            castleHealthPricesText[4].text = PlayerPrefs.GetFloat("fifthcastlehealthmoney").ToString();
            castleHealthText[4].enabled = true;
        }
    }


    public void FirstCastleBuyButton()
    {

    }
    public void SecondCastleBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 2500)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 2500);
            PlayerPrefs.SetInt("currentcastleindex", 1);
            PlayerPrefs.SetString("buysecondcastle", "true");
            Tick(1);
        }
        Is_Bought("buysecondcastle", 1);
    }
    public void ThirdCastleBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 7500)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 7500);
            PlayerPrefs.SetInt("currentcastleindex", 2);
            PlayerPrefs.SetString("buythirdcastle", "true");
            Tick(2);
        }
        Is_Bought("buythirdcastle", 2);
    }
    public void FourthCastleBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 15000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 15000);
            PlayerPrefs.SetInt("currentcastleindex", 3);
            PlayerPrefs.SetString("buyfourthcastle", "true");
            Tick(3);
        }
        Is_Bought("buyfourthcastle", 3);
    }
    public void FifthCastleBuyButton()
    {
        if (PlayerPrefs.GetFloat("money") >= 25000)
        {
            audioSource.PlayOneShot(buySound);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - 25000);
            PlayerPrefs.SetInt("currentcastleindex", 4);
            PlayerPrefs.SetString("buyfifthcastle", "true");
            Tick(4);
        }
        Is_Bought("buyfifthcastle", 4);
    }



    public void FirstCastleChooseButton()
    {
        PlayerPrefs.SetInt("currentcastleindex", 0);
        audioSource.PlayOneShot(chooseSound);
        Tick(0);
    }
    public void SecondCastleChooseButton()
    {
        PlayerPrefs.SetInt("currentcastleindex", 1);
        audioSource.PlayOneShot(chooseSound);
        Tick(1);
    }
    public void ThirdCastleChooseButton()
    {
        PlayerPrefs.SetInt("currentcastleindex", 2);
        audioSource.PlayOneShot(chooseSound);
        Tick(2);
    }
    public void FourthCastleChooseButton()
    {
        PlayerPrefs.SetInt("currentcastleindex", 3);
        audioSource.PlayOneShot(chooseSound);
        Tick(3);
    }
    public void FifthCastleChooseButton()
    {
        PlayerPrefs.SetInt("currentcastleindex", 4);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirstcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 0)
                {
                    Is_Bought("buyfirstcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 1)
                {
                    Is_Bought("buysecondcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 2)
                {
                    Is_Bought("buythirdcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 3)
                {
                    Is_Bought("buyfourthcastle", i);
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
            for (int i = 0; i < castleBuyButton.Length; i++)
            {
                if (i == 4)
                {
                    Is_Bought("buyfifthcastle", i);
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
            castlePrices[i].SetActive(false);
            castleBuyButton[i].SetActive(false);
            castleChooseButton[i].SetActive(true);
            castleGameobjects[i].SetActive(true);

            castleHealthPricesText[i].enabled = true;
            castleHealthButtons[i].SetActive(true);
            castleHealthText[i].enabled = true;
            balistaPowerMoneyIcons[i].SetActive(true);
        }
        else
        {
            castlePrices[i].SetActive(true);
            castleBuyButton[i].SetActive(true);
            castleChooseButton[i].SetActive(false);
            castleGameobjects[i].SetActive(true);

            castleHealthPricesText[i].enabled = false;
            castleHealthButtons[i].SetActive(false);
            castleHealthText[i].enabled = false;
            balistaPowerMoneyIcons[i].SetActive(false);
        }
    }

    private void Not_Bought(int i)
    {
        castlePrices[i].SetActive(false);
        castleBuyButton[i].SetActive(false);
        castleChooseButton[i].SetActive(false);
        castleGameobjects[i].SetActive(false);

        castleHealthPricesText[i].enabled = false;
        castleHealthButtons[i].SetActive(false);
        castleHealthText[i].enabled = false;
        balistaPowerMoneyIcons[i].SetActive(false);
    }

    private void Tick(int i)
    {
        if (PlayerPrefs.GetInt("currentcastleindex") == i)
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
        if (PlayerPrefs.GetInt("currentcastleindex") == 0 && index == 0)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("firstcastlehealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("firstcastlehealthmoney"));
                PlayerPrefs.SetFloat("firstcastlehealth", PlayerPrefs.GetFloat("firstcastlehealth") + 50);
                PlayerPrefs.SetFloat("firstcastlehealthmoney", PlayerPrefs.GetFloat("firstcastlehealthmoney") + 50);
                castleHealthText[0].text = "HEALTH : " + PlayerPrefs.GetFloat("firstcastlehealth");
                castleHealthPricesText[0].text = PlayerPrefs.GetFloat("firstcastlehealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentcastleindex") == 1 && index == 1)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("secondcastlehealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("secondcastlehealthmoney"));
                PlayerPrefs.SetFloat("secondcastlehealth", PlayerPrefs.GetFloat("secondcastlehealth") + 50);
                PlayerPrefs.SetFloat("secondcastlehealthmoney", PlayerPrefs.GetFloat("secondcastlehealthmoney") + 50);
                castleHealthText[1].text = "HEALTH : " + PlayerPrefs.GetFloat("secondcastlehealth");
                castleHealthPricesText[1].text = PlayerPrefs.GetFloat("secondcastlehealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentcastleindex") == 2 && index == 2)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("thirdcastlehealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("thirdcastlehealthmoney"));
                PlayerPrefs.SetFloat("thirdcastlehealth", PlayerPrefs.GetFloat("thirdcastlehealth") + 50);
                PlayerPrefs.SetFloat("thirdcastlehealthmoney", PlayerPrefs.GetFloat("thirdcastlehealthmoney") + 50);
                castleHealthText[2].text = "HEALTH : " + PlayerPrefs.GetFloat("thirdcastlehealth");
                castleHealthPricesText[2].text = PlayerPrefs.GetFloat("thirdcastlehealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentcastleindex") == 3 && index == 3)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fourthcastlehealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fourthcastlehealthmoney"));
                PlayerPrefs.SetFloat("fourthcastlehealth", PlayerPrefs.GetFloat("fourthcastlehealth") + 50);
                PlayerPrefs.SetFloat("fourthcastlehealthmoney", PlayerPrefs.GetFloat("fourthcastlehealthmoney") + 50);
                castleHealthText[3].text = "HEALTH : " + PlayerPrefs.GetFloat("fourthcastlehealth");
                castleHealthPricesText[3].text = PlayerPrefs.GetFloat("fourthcastlehealthmoney").ToString();
            }
        }
        if (PlayerPrefs.GetInt("currentcastleindex") == 4 && index == 4)
        {
            if (PlayerPrefs.GetFloat("money") >= PlayerPrefs.GetFloat("fifthcastlehealthmoney"))
            {
                audioSource.PlayOneShot(UpgradeSound);
                PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") - PlayerPrefs.GetFloat("fifthcastlehealthmoney"));
                PlayerPrefs.SetFloat("fifthcastlehealth", PlayerPrefs.GetFloat("fifthcastlehealth") + 50);
                PlayerPrefs.SetFloat("fifthcastlehealthmoney", PlayerPrefs.GetFloat("fifthcastlehealthmoney") + 50);
                castleHealthText[4].text = "HEALTH : " + PlayerPrefs.GetFloat("fifthcastlehealth");
                castleHealthPricesText[4].text = PlayerPrefs.GetFloat("fifthcastlehealthmoney").ToString();
            }
        }
    }
}
