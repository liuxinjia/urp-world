using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// We will use this class to receive animation events from our Animator component.
    /// </summary>
    public class CharacterAnimEvents : MonoBehaviour
    {
        // =============================================================================================================
        /// <summary>
        /// This function will be called directly from our Animation event, when it reaches a certain frame.
        /// </summary>
        private void AttackHit()
        {
            //Send this function call to all parent objects (expensive method, use it with caution)
            //Here I did this because we can call this for our player or our enemy
            SendMessageUpwards("AttackCheckHit");
        }
        // =============================================================================================================
    }
}
