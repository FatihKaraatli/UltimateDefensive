using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject enemy;
    public GameObject strongEnemy;
    public GameObject goblin;
    public GameObject golem;
    public GameObject ram;

    void Start()
    {
        if (PlayerPrefs.GetFloat("level") == 0)
        {
            PlayerPrefs.SetInt("enemyCount", 1);
            PlayerPrefs.SetInt("strongEnemyCount", 1);
            PlayerPrefs.SetInt("goblinCount", 1);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 1)
        {
            PlayerPrefs.SetInt("enemyCount", 2);
            PlayerPrefs.SetInt("strongEnemyCount", 1);
            PlayerPrefs.SetInt("goblinCount", 2);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 2)
        {
            PlayerPrefs.SetInt("enemyCount", 3);
            PlayerPrefs.SetInt("strongEnemyCount", 2);
            PlayerPrefs.SetInt("goblinCount", 3);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 3)
        {
            PlayerPrefs.SetInt("enemyCount", 3);
            PlayerPrefs.SetInt("strongEnemyCount", 3);
            PlayerPrefs.SetInt("goblinCount", 3);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 4)
        {
            PlayerPrefs.SetInt("enemyCount", 4);
            PlayerPrefs.SetInt("strongEnemyCount", 3);
            PlayerPrefs.SetInt("goblinCount", 4);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 5)
        {
            PlayerPrefs.SetInt("enemyCount", 2);
            PlayerPrefs.SetInt("strongEnemyCount", 5);
            PlayerPrefs.SetInt("goblinCount", 2);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 6)
        {
            PlayerPrefs.SetInt("enemyCount", 5);
            PlayerPrefs.SetInt("strongEnemyCount", 3);
            PlayerPrefs.SetInt("goblinCount", 3);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 7)
        {
            PlayerPrefs.SetInt("enemyCount", 2);
            PlayerPrefs.SetInt("strongEnemyCount", 3);
            PlayerPrefs.SetInt("goblinCount", 7);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 8)
        {
            PlayerPrefs.SetInt("enemyCount", 4);
            PlayerPrefs.SetInt("strongEnemyCount", 4);
            PlayerPrefs.SetInt("goblinCount", 4);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 9)
        {
            PlayerPrefs.SetInt("enemyCount", 1);
            PlayerPrefs.SetInt("strongEnemyCount", 1);
            PlayerPrefs.SetInt("goblinCount", 1);
            PlayerPrefs.SetInt("golemCount", 1);
            PlayerPrefs.SetInt("ramCount", 0);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") == 10)
        {
            PlayerPrefs.SetInt("enemyCount", 1);
            PlayerPrefs.SetInt("strongEnemyCount", 1);
            PlayerPrefs.SetInt("goblinCount", 1);
            PlayerPrefs.SetInt("golemCount", 0);
            PlayerPrefs.SetInt("ramCount", 1);
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") % 15 == 0)
        {
            if (PlayerPrefs.GetFloat("level") < 50)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 5);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("golemCount", 1);
                PlayerPrefs.SetInt("ramCount", 1);
            }
            else if (PlayerPrefs.GetFloat("level") < 100)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 7);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("golemCount", 1);
                PlayerPrefs.SetInt("ramCount", 2);
            }
            else if (PlayerPrefs.GetFloat("level") <= 150)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 9);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("golemCount", 2);
                PlayerPrefs.SetInt("ramCount", 2);
            }
            else
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 12);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("golemCount", (int)PlayerPrefs.GetFloat("level") / 50);
                PlayerPrefs.SetInt("ramCount", (int)PlayerPrefs.GetFloat("level") / 50);
            }
            FirstToTenLevel();
        }
        else if (PlayerPrefs.GetFloat("level") % 3 == 0)
        {
            if (PlayerPrefs.GetFloat("level") < 50)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 5);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 1);
            }
            else if (PlayerPrefs.GetFloat("level") < 100)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 7);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 2);
            }
            else if (PlayerPrefs.GetFloat("level") <= 150)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 9);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 2);
            }
            else
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 12);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", (int)PlayerPrefs.GetFloat("level") / 50);
            }
            FirstToTenLevel();
        } 
        else if (PlayerPrefs.GetFloat("level") % 5 == 0)
        {
            if (PlayerPrefs.GetFloat("level") < 50)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 5);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("golemCount", 1);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else if (PlayerPrefs.GetFloat("level") < 100)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 7);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("golemCount", 1);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else if (PlayerPrefs.GetFloat("level") <= 150)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 9);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("golemCount", 2);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 12);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("golemCount", (int)PlayerPrefs.GetFloat("level") / 50);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            FirstToTenLevel();
        }
        else
        {
            if (PlayerPrefs.GetFloat("level") < 50)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 5);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 4);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else if (PlayerPrefs.GetFloat("level") < 100)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 7);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 6);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else if (PlayerPrefs.GetFloat("level") < 150)
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 9);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 8);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            else
            {
                PlayerPrefs.SetInt("enemyCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("strongEnemyCount", (int)PlayerPrefs.GetFloat("level") / 12);
                PlayerPrefs.SetInt("goblinCount", (int)PlayerPrefs.GetFloat("level") / 10);
                PlayerPrefs.SetInt("golemCount", 0);
                PlayerPrefs.SetInt("ramCount", 0);
            }
            FirstToTenLevel();
        }
    }


    public void FirstToTenLevel()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("goblinCount"); i++)
        {
            Instantiate(goblin, new Vector3(Random.Range(-15f, 15f), this.gameObject.transform.position.y, Random.Range(140f, 170f)), Quaternion.identity);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("enemyCount"); i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(-15f, 15f), this.gameObject.transform.position.y, Random.Range(140f, 170f)), Quaternion.identity);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("strongEnemyCount"); i++)
        {
            Instantiate(strongEnemy, new Vector3(Random.Range(-15f, 15f), this.gameObject.transform.position.y, Random.Range(140f, 170f)), Quaternion.identity);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("golemCount"); i++)
        {
            Instantiate(golem, new Vector3(Random.Range(-15f, 15f), this.gameObject.transform.position.y, Random.Range(140f, 170f)), Quaternion.identity);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("ramCount"); i++)
        {
            Instantiate(ram, new Vector3(Random.Range(-15f, 15f), this.gameObject.transform.position.y, Random.Range(140f, 170f)), Quaternion.identity);
        }
    }


}
