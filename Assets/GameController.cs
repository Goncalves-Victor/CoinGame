using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayerController player;
    public AiController ai;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI messageText; 
    private bool gameEnded = false;

    void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }
        if (ai == null)
        {
            ai = FindObjectOfType<AiController>();
        }
    }

    void Update()
    {
    
        if (scoreText != null)
        {
            scoreText.text = "VOCÊ: " + player.playerScore + "  ROBERTA: " + ai.aiScore;
        }

        if (!gameEnded && GameObject.FindGameObjectsWithTag("Coin").Length == 0)
        {
            gameEnded = true;
            DetermineWinner();
            Invoke("ReturnToMenu", 3f); 
        }
    }

    void DetermineWinner()
    {
        if (player.playerScore > ai.aiScore)
        {
            if (messageText != null) messageText.text = "VOCÊ GANHOU!";
        }
        else if (player.playerScore < ai.aiScore)
        {
            if (messageText != null) messageText.text = "VOCÊ PERDEU!";
        }
       
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
