using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Creates enemies in real time.
    /// </summary>
    public class EnemySpawner : MonoBehaviour
    {
        [Tooltip("Where our enemies will spawn from?")]
        public Transform spawnPosition;
        [Tooltip("What we should spawn?")]
        public GameObject enemyPrefab;
        [Tooltip("Seconds to wait before the next spawn.")]
        public float timerToCreateEnemy = 5;
        [Tooltip("We want to make sure the character is either alive or won the match")]
        public CharacterBase playerCharacter;
        [Tooltip("We want to make sure the character is either alive or won the match")]
        public GameController gameController;
        
        /// <summary>
        /// Check timer to spawn
        /// </summary>
        private float currentTimer;
        
        // =============================================================================================================
        private void Start()
        {
            currentTimer = timerToCreateEnemy;
        }
        // =============================================================================================================
        private void Update()
        {
            if (gameController.gameFinished || playerCharacter.healthPoints <= 0)
                return;

            currentTimer -= Time.deltaTime;
            if (currentTimer <= 0)
            {
                currentTimer = timerToCreateEnemy;
                Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            }
        }
        // =============================================================================================================
    }
}
