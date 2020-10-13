using UnityEngine;

namespace Workshop1.Scripts
{
    /// <summary>
    /// Common functions and events from Unity.
    /// </summary>
    public class MyHelloWorld : MonoBehaviour
    {
        [Header("====== Hello world Tests")]
        
        [Tooltip("Shows a help text if you mouse your mouse over")]
        [SerializeField] private string myMsg = "Hello world";
        
        [Tooltip("An automated range value on editor.")]
        [Range(0, 2)]
        [SerializeField] private float mySlider = 0.5f;
        
        [Tooltip("Boolean to show something on screen after a few seconds.")]
        [SerializeField] private bool showAutomatedMsg;

        /// <summary>
        /// Save our timer, in case we want to use it.
        /// </summary>
        private float msgTimer;
        /// <summary>
        /// Just to increment our timer and concatenate
        /// </summary>
        private int counterForTimer;
        
        // =============================================================================================================
        private void Awake()
        {
            
        }
        // =============================================================================================================
        private void OnEnable()
        {
            
        }
        // =============================================================================================================
        private void Start()
        {
            //Set our timer initially
            msgTimer = mySlider;
        }
        // =============================================================================================================
        private void OnCollisionEnter(Collision other)
        {
            
        }
        // =============================================================================================================
        private void OnCollisionExit(Collision other)
        {
            
        }
        // =============================================================================================================
        private void OnTriggerEnter(Collider other)
        {
            
        }
        // =============================================================================================================
        private void FixedUpdate()
        {
            
        }
        // =============================================================================================================
        private void Update()
        {
            //Shows a msg every few seconds?
            if (showAutomatedMsg)
            {
                //Decrease the time per second
                msgTimer -= Time.deltaTime;
                if (msgTimer <= 0)
                {
                    msgTimer = mySlider;
                    counterForTimer++;
                    //Shows the message into our Console window
                    Debug.Log(myMsg + " " + counterForTimer);
                }
            }
        }
        // =============================================================================================================
        private void LateUpdate()
        {
            
        }
        // =============================================================================================================
    }
}
