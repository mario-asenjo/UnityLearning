using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float decceleration = 0.5f;
    int VelocityHash;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        VelocityHash = Animator.StringToHash("Velocity"); 
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool l_shiftPressed = Input.GetKey("left shift");
        if (forwardPressed && velocity < 1.0f)
        {
            animator.SetBool("isWalking", true);
            velocity += Time.deltaTime * acceleration;
        }
        
        if (!forwardPressed && velocity > 0.0f)
        {
            animator.SetBool("isWalking", false);
            velocity -= Time.deltaTime * decceleration;
        }

        if (velocity < 0.0f)
        {
            velocity = 0.0f;
        }

        animator.SetFloat(VelocityHash, velocity);
    }
}
