using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text scoreText;
    public Text healthText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameManager.insntance.score.ToString();
        healthText.text = GameManager.insntance.health.ToString();
    }
}
