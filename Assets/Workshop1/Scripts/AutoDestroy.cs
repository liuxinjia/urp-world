using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Simply make this game object to self destroy.
    /// NOTE: this is not ideal in a game, since if we instantiate or destroy too many times during our game,
    /// it will call a lot the garbage collector, impacting the overall performance. For this demo, is fine.
    /// </summary>
    public class AutoDestroy : MonoBehaviour
    {
        [Tooltip("Seconds to destroy after some time.")]
        public float timer = 2;
        
        // =============================================================================================================
        private void Start()
        {
            Destroy(gameObject, timer);
        }
        // =============================================================================================================
    }
}
