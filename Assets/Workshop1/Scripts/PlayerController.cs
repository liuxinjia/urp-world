using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Main script for our player, to move, rotate, attack enemies and also die.
    /// The player has basic inputs from the keyboard, we don't need the mouse on this one.
    /// </summary>
    public class PlayerController : CharacterBase
    {
        // =============================================================================================================
        private void FixedUpdate()
        {
            HandleMovement();
        }
        // =============================================================================================================
        /// <summary>
        /// Make our character to move and rotate to the direction we want.
        /// </summary>
        private void HandleMovement()
        {
            //I can't move if I am attacking or dead
            if (waitingAttackTimer > 0 || isDead)
                return;
            
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            
            //MOVE
            myRigidbody.AddForce(new Vector3(moveHorizontal, 0, moveVertical) * moveSpeed, ForceMode.Impulse);
            
            //ROTATE
            //If I am sending inputs, make the move rotation
            if (Mathf.Abs(moveHorizontal) > 0 || Mathf.Abs(moveVertical) > 0)
            {
                var rotControl = new Vector3(moveHorizontal, 0, moveVertical);
                characterGraphics.rotation = Quaternion.LookRotation(rotControl);
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Make this enemy attack the player if it is near enough
        /// </summary>
        protected override void HandleAttacks()
        {
            base.HandleAttacks();

            if (waitingAttackTimer > 0 || isDead)
                return;
            
            //If we press the correct key, sends the attack
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
            {
                // Debug.Log("Sending attack call...");
                waitingAttackTimer = attackWaitTimer;
                myAnimator.SetTrigger("Attack");
            }
        }
        // =============================================================================================================
        protected override void SetDead()
        {
            base.SetDead();
            
        }
        // =============================================================================================================
    }
}
