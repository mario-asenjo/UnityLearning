using UnityEngine;

public class twoDimensionalStateController : MonoBehaviour
{
    Animator animator;
    float velocityX = 0f;
    float velocityZ = 0f;
    public float acceleration = 2f;
    public float decceleration = 2f;
    public float maxVelWalking = 0.5f;
    public float maxVelRunning = 2f;
    int velocityZHash;
    int velocityXHash;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        velocityXHash = Animator.StringToHash("VelocityX");
        velocityZHash = Animator.StringToHash("VelocityZ");
    }

    // Update is called once per frame
    void Update()
    {
        //Input del usuario
        //Serán verdaderas cuando el usuario esté presionando la tecla a la que este asociado cada KeyCode
        bool wPressed = Input.GetKey(KeyCode.W);
        bool aPressed = Input.GetKey(KeyCode.A);
        bool dPressed = Input.GetKey(KeyCode.D);
        bool sPressed = Input.GetKey(KeyCode.S);
        bool lShiftPressed = Input.GetKey(KeyCode.LeftShift);

        float currentMaxVel = lShiftPressed ? maxVelRunning : maxVelWalking;

        //Increase velocity
        if (wPressed && velocityZ < currentMaxVel)
        {
            velocityZ += Time.deltaTime * acceleration;
        }

        if (sPressed && velocityZ > -currentMaxVel)
        {
            velocityZ -= Time.deltaTime * acceleration;
        }

        if (dPressed && velocityX < currentMaxVel)
        {
            velocityX += Time.deltaTime * acceleration;    
        }

        if (aPressed && velocityX > -currentMaxVel)
        {
            velocityX -= Time.deltaTime * acceleration;
        }

        //Decrease velocity
        if (!wPressed && velocityZ > 0.0f)
        {
            velocityZ -= Time.deltaTime * decceleration;
        }

        if (!sPressed && velocityZ < 0.0f)
        {
            velocityZ += Time.deltaTime * decceleration;
        }

        if (!dPressed && velocityX > 0.0f)
        {
            velocityX -= Time.deltaTime * decceleration;
        }

        if (!aPressed && velocityX < 0.0f)
        {
            velocityX += Time.deltaTime * decceleration;
        }

        //lock forward
        if (wPressed && lShiftPressed && velocityZ > currentMaxVel)
        {
            velocityZ = currentMaxVel;
        }
        else if (wPressed && velocityZ > currentMaxVel)
        {
            velocityZ -= Time.deltaTime * decceleration;
            if (velocityZ > currentMaxVel && velocityZ < (currentMaxVel + 0.5f))
            {
                velocityZ = currentMaxVel;
            }
        }
        else if (wPressed && velocityX < currentMaxVel && velocityX > (currentMaxVel - 0.5f))
        {
            velocityZ = currentMaxVel;
        }

        //lock left
        if (aPressed && lShiftPressed && velocityX < -currentMaxVel)
        {
            velocityX = -currentMaxVel;
        }
        else if (aPressed && velocityX < -currentMaxVel)
        {
            velocityX += Time.deltaTime * decceleration;
            if (velocityX < -currentMaxVel && velocityX > (-currentMaxVel - 0.5f))
            {
                velocityX = -currentMaxVel;
            }
        }
        else if (aPressed && velocityX > -currentMaxVel && velocityX < (-currentMaxVel + 0.5f))
        {
            velocityX = -currentMaxVel;
        }

        //lock right
        if (dPressed && lShiftPressed && velocityX > currentMaxVel)
        {
            velocityX = currentMaxVel;
        }
        else if (dPressed && velocityX > currentMaxVel)
        {
            velocityX -= Time.deltaTime * decceleration;
            if (velocityX > currentMaxVel && velocityX < (currentMaxVel + 0.5f))
            {
                velocityX = currentMaxVel;
            }
        }
        else if (dPressed && velocityX < currentMaxVel && velocityX > (currentMaxVel - 0.5f))
        {
            velocityX = currentMaxVel;
        }

        animator.SetFloat(velocityXHash, velocityX);
        animator.SetFloat(velocityZHash, velocityZ);
    }
}
