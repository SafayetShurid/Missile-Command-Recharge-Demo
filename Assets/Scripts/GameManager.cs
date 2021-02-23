using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public int health;

    public static GameManager insntance;

    private void Awake()
    {
        insntance = this;
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ScoreUp()
    {
        score++;
    }

    public void HealthDown()
    {
        health--;
    }
}
