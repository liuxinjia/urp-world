using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Base data for all characters for this workshop demo.
    /// </summary>
    public class CharacterBase : MonoBehaviour
    {
        [Header("====== Character Data")]
        [Tooltip("Player health points, if it reaches zero, player loses.")]
        public float healthPoints = 100;
        [Tooltip("Is this character dead already?")]
        public bool isDead;
        
        [Header("====== Graphics")]
        [Tooltip("The character graphics to make it rotate.")]
        public Transform characterGraphics;
        
        [Header("====== Movement")]
        [Tooltip("My move speed.")]
        public float moveSpeed = 40;
        
        [Header("====== Attacks")]
        [Tooltip("How long an attack lasts?")]
        public float attackWaitTimer = 1.2f;
        [Tooltip("How long our attack can reach?")]
        public float attackDistance = 1.5f;
        [Tooltip("How strong is our damage?")]
        public float damagePower = 20;
        [Tooltip("What can we hit?")]
        public LayerMask enemyLayers;
        
        /// <summary>
        /// Cached data for Rigidbody component.
        /// </summary>
        internal Rigidbody myRigidbody;
        /// <summary>
        /// Cached data for Animator component.
        /// </summary>
        internal Animator myAnimator;
        /// <summary>
        /// How long should we wait for the next attack input?
        /// </summary>
        internal float waitingAttackTimer;
        
        // =============================================================================================================
        protected virtual void Start()
        {
            //Get the components from our game object
            myRigidbody = GetComponent<Rigidbody>();
            myAnimator = GetComponentInChildren<Animator>();
        }
        // =============================================================================================================
        private void Update()
        {
            HandleAnimation();
            HandleAttacks();
        }
        // =============================================================================================================
        /// <summary>
        /// Animate our player based on movement.
        /// </summary>
        protected void HandleAnimation()
        {
            if (isDead)
                return;
            myAnimator.SetFloat("Move", myRigidbody.velocity.magnitude);
            // Debug.Log(myRigidbody.velocity.magnitude);
        }
        // =============================================================================================================
        /// <summary>
        /// Handles our attack timer. We will check inputs depending if it is enemy or player.
        /// </summary>
        protected virtual void HandleAttacks()
        {
            //Do I need to wait to try to attack again?
            if (waitingAttackTimer > 0)
            {
                waitingAttackTimer -= Time.deltaTime;
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Check the hit call, so we can see if we will hit something. This was done to make the attack animation more 
        /// accurate and fun. Called from CharacterAnimEvents.
        /// Another possible way: We could also create a Trigger call through the collision trigger on the sword.
        /// </summary>
        public void AttackCheckHit()
        {
            // Debug.Log("Checking hit...");
            //Check if we have any enemies in the same side our graphics is rotated to.
            var ray = new Ray(characterGraphics.position, characterGraphics.forward);
            if (Physics.SphereCast(ray, 0.5f, out var hit, attackDistance, enemyLayers))
            {
                //ON GROUND
                Debug.DrawRay(characterGraphics.position, characterGraphics.forward, Color.yellow);
                Debug.Log("We hit an enemy: " + hit.transform.name);
                var characterHit = hit.transform.GetComponent<CharacterBase>();
                characterHit.ReceiveDamage(damagePower);
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Player and enemy receives damage.
        /// </summary>
        /// <param name="dmgAmount"></param>
        private void ReceiveDamage(float dmgAmount)
        {
            if (isDead)
                return;
            healthPoints -= dmgAmount;
            if (healthPoints <= 0)
            {
                SetDead();
            }
        }
        // =============================================================================================================
        /// <summary>
        /// Set character dead. Making it virtual, we can create different behaviours, like for the player we want
        /// to show the end screen, etc. For the enemy, we just want him to explode, LOL.
        /// </summary>
        protected virtual void SetDead()
        {
            healthPoints = 0;
            isDead = true;
            myRigidbody.isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
            myAnimator.SetTrigger("Dead");
        }
        // =============================================================================================================
    }
}
