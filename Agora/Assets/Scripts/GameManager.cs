using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; set;}

    [Header("General")]
    public Player player;

    [Header("Score")]
    public Text scoreText;

    void Awake() 
    {
        Instance = this;
    }

    public void UpdateScore()
    {
        player.score++;
        scoreText.text = player.score.ToString();
    }
}
