using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip jumpSound;
    public AudioClip crashSound;


    public float jumpForce = 1;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            dirt.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            isGameOver = true;
            Debug.Log("Game Over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
        }
    }
}
