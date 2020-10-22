using UnityEngine;
using UnityEngine.SceneManagement;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Handles main menu to start and exit the game
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [Tooltip("Add the name of the scene for your game.")]
        public string gameLevelName = "Game";
        
        // =============================================================================================================
        /// <summary>
        /// Simply quits the game.
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
        }
        // =============================================================================================================
        /// <summary>
        /// Starts our game to the level we named.
        /// </summary>
        public void StartGame()
        {
            SceneManager.LoadScene(gameLevelName);
        }
        // =============================================================================================================
    }
}
