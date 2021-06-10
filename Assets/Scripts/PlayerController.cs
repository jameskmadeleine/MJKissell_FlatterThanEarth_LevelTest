using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Serializable]
    public class References
    {
        public Rigidbody RigidBody;
        public CapsuleCollider CapsuleCollider;
    }

    [Serializable]
    public class Settings
    {
        [Tooltip("Maximum slope the character can jump on")]
        [Range(5f, 60f)]
        public float SlopeLimit = 45f;
        [Tooltip("Move speed in meters/second")]
        public float MoveSpeed = 2f;
        [Space]
        [Tooltip("Whether the character can jump")]
        public bool AllowJump = false;
        [Tooltip("Force of a jump")]
        public float JumpForce = 4f;
        [Tooltip("Type of force added to rigidbody while try jump")]
        public ForceMode JumpForceMode = ForceMode.Impulse;

        [Space]
        [Tooltip("Ground Layer")]
        public LayerMask GroundLayer;
        [Tooltip("Ground raycast distance")]
        public float GroundCheckerDistance;
    }


    [SerializeField] References _references;
    [SerializeField] Settings _settings;


    
    private float _forwardInput;
    private float _turnInput;
    


   


    private void Update()
    {
        this.UpdateInputState();
        
    }

    private void UpdateInputState()
    {
        _forwardInput = Mathf.RoundToInt(Input.GetAxis("Vertical"));
        _turnInput = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        
    }

  
    public void OnCheckpointRespawn(Checkpoint checkpoint)
    {
        this.transform.position = checkpoint.RespawnPostitionTransform.position;
    }
}
