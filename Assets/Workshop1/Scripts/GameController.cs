using System;
using TMPro;
using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// We will handle our game logic here, for score, UI and player health display.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        [Header("====== Game Data")]
        [Tooltip("Is the game finished?")]
        public bool gameFinished;
        [Tooltip("How much score points the player gain per kill?")]
        public int scorePerKill = 10;
        [Tooltip("How much score points we need to win?")]
        public int scoreToWin = 100;
        [Tooltip("How much health the player starts with?")]
        public float playerStartingHealth = 100;

        [Header("====== UI (User Interface)")]
        public TextMeshProUGUI uiScore;
        public TextMeshProUGUI uiPlayerHealth;
        public GameObject uiGameWon;
        public GameObject uiGameLost;

        /// <summary>
        /// Our current score for the game.
        /// </summary>
        private int currentScore;
        /// <summary>
        /// Current player health.
        /// </summary>
        private float currentPlayerHealth;

        // =============================================================================================================
        private void Start()
        {
            //Make sure we reset everything
            currentScore = 0;
            currentPlayerHealth = playerStartingHealth;
            uiScore.text = "Score: " + currentScore;
            uiPlayerHealth.text = "Health: " + currentPlayerHealth;
            uiGameWon.SetActive(false);
            uiGameLost.SetActive(false);
        }
        // =============================================================================================================
        /// <summary>
        /// Add score point for the player.
        /// </summary>
        public void AddScore()
        {
            currentScore += scorePerKill;
            uiScore.text = "Score: " + currentScore;
            
            //Check if we won
            if (currentScore >= scoreToWin)
            {
                FinishTheGame(true);
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Update player's health.
        /// </summary>
        public void UpdateHealth(float newHealth)
        {
            currentPlayerHealth = newHealth;
            uiPlayerHealth.text = "Health: " + currentPlayerHealth;
            
            //Check if we won
            if (currentPlayerHealth <= 0)
            {
                FinishTheGame(false);
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Let's call this to finish the game.
        /// </summary>
        /// <param name="didWeWin">If true, it means we won, false, means we lost.</param>
        private void FinishTheGame(bool didWeWin)
        {
            gameFinished = true;
            uiGameWon.SetActive(didWeWin);
            uiGameLost.SetActive(!didWeWin);
        }
        // =============================================================================================================
    }
}
