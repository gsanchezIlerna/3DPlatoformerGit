using System;
using UnityEngine;
using UnityEngine.Timeline;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]  private float speed;
    [SerializeField]  private Vector3 jumpForce;
    private Vector3 movementDirection;
    private Vector3 movementJumpDirection;
    private bool isGrounded;
    private bool canDoubleJump;
    public ParticleSystem particle;
   
    private Rigidbody rb;
    public Animator animator;
    private bool isDashing;
    [SerializeField] private float dashDistance = 100;
    private bool isPlayingParticle;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator.SetBool("isGrounded", isGrounded);
        particle.Stop();
        isPlayingParticle = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isJumping", false);//Reseteo aqui el valor de la variable del animator para evitar que no se actualice su valor en un unico frame, lo cual no reproduce la animacion
        isDashing = false;

        //Movement inputs
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        float cameraPositionX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * cameraPositionX);
        

        //doy valor al parametro del animator segun el input para cambiar los estado de animacion.
        animator.SetFloat("movZ", movZ);
        animator.SetFloat("movX", movX);

        movementDirection = transform.right * movX + transform.forward * movZ;

        if (movementDirection.magnitude > 1)
            movementDirection.Normalize();

        if (isGrounded)
        {
            rb.linearVelocity = new Vector3(movementDirection.x * speed, rb.linearVelocity.y, movementDirection.z * speed);
        }
        else
        {
            rb.linearVelocity = new Vector3(movementJumpDirection.x * speed, rb.linearVelocity.y, movementJumpDirection.z * speed);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                movementJumpDirection = movementDirection;
                Jump();

            }
            else if (canDoubleJump)
            {
                movementJumpDirection = movementDirection;
                Jump();
                canDoubleJump = false; // Desactivar el doble salto tras el segundo salto
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) { 
            if (isGrounded) 
            {
                Dash(); 
            }
        }

        ParticleSystemStartStop();
    }

    private void ParticleSystemStartStop()
    {
        if ( isGrounded && (rb.linearVelocity != Vector3.zero))
        {
            particle.Play();
            isPlayingParticle = false;
        }
        else
        {
            particle.Stop();

        }
    }
    private void Dash()
    {
        
        Vector3 dashDirection = transform.forward * dashDistance;
        transform.position += dashDirection;

        isDashing = true;
        animator.SetBool("isDashing", isDashing);
    }

    void Jump() 
    {
        animator.SetBool("isJumping", true);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Restablecemos la velocidad vertical
        rb.AddForce( jumpForce  , ForceMode.Force);
        
    }
    private void OnCollisionEnter(Collision collision)
    {

       
        foreach (ContactPoint contact in collision.contacts)
        {
            // Detectar si estamos en el suelo
            if (contact.normal.y > 0.7f)
            {
                isGrounded = true;
                animator.SetBool("isGrounded", isGrounded);
                canDoubleJump = true; // Restablecer el doble salto cuando tocamos el suelo
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; // Salimos del suelo
        animator.SetBool("isGrounded", isGrounded);
    }

}
