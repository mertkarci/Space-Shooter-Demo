using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject astroid;
    public Vector3 randomPos;
    int score;
    public Text scoreBoard;
    public bool isgameFinished = false;
    void Start()
    {
        isgameFinished = false;
        score = 0;
        scoreBoard.text = "SCORE = " + score;


        StartCoroutine(olustur());
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(astroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(6);
            if (isgameFinished == true)
            {
                break;
            }
        }
    }

    public void ScoreAdd(int earnScore)
    {
        score += earnScore;
        scoreBoard.text = "SCORE = " + score;
        Debug.Log(score);
    }
    public void gameOver()
    {

        isgameFinished = true;
        SceneManager.LoadScene("menu");

    }
}