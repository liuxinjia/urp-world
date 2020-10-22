using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Our enemy will look for the player right from the start and it will pursue.
    /// They have basic attacks and can deliver damage.
    /// </summary>
    public class EnemyController : CharacterBase
    {
        [Header("====== Enemy Data")]
        [Tooltip("The target for the enemy to pursue. It will auto set.")]
        public GameObject myTarget;

        /// <summary>
        /// We will check if the target is close enough to make an attack
        /// </summary>
        private bool targetIsClose;
        /// <summary>
        /// We want to get the values from the player target, to check if he is dead or not.
        /// </summary>
        private CharacterBase playerTarget;
        
        // =============================================================================================================
        protected override void Start()
        {
            base.Start();
            myTarget = GameObject.FindWithTag("Player");
            playerTarget = myTarget.GetComponent<CharacterBase>();
        }
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
            if (waitingAttackTimer > 0 || isDead || myTarget == null || gameController.gameFinished)
                return;
            
            //Rotate to target
            var direction = (myTarget.transform.position - myRigidbody.position).normalized;
            var lookRotation = Quaternion.LookRotation(direction);
            var rotation = myRigidbody.rotation;
            rotation = Quaternion.Slerp(rotation, lookRotation, Time.deltaTime * 10);
            rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
            myRigidbody.MoveRotation(rotation);
            
            //Move to target
            targetIsClose = true;
            var distance = Vector3.Distance(myTarget.transform.position, transform.position);
            if (distance > attackDistance)
            {
                myRigidbody.AddForce(myRigidbody.transform.forward * moveSpeed, ForceMode.Impulse);
                targetIsClose = false;
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Make this enemy attack the player if it is near enough
        /// </summary>
        protected override void HandleAttacks()
        {
            base.HandleAttacks();

            if (waitingAttackTimer > 0 || isDead || gameController.gameFinished)
                return;
            
            //Send the attack as soon as possible
            if (targetIsClose)
            {
                // Debug.Log("Sending attack call...");
                waitingAttackTimer = attackWaitTimer;
                myAnimator.SetTrigger("Attack");
                targetIsClose = false;
            }
        }
        // =============================================================================================================
        protected override void SetDead()
        {
            base.SetDead();
            gameController.AddScore();
        }
        // =============================================================================================================
    }
}
