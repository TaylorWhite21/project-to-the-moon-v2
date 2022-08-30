using UnityEngine;

public class Movement : MonoBehaviour
{
    // Controls player movement speed
    [SerializeField] float thrustForceUp = 50f;
    [SerializeField] float rotationThrust = 50f;
    // Allows you to assign an audio clip in the engine
    [SerializeField] AudioClip mainEngine;

    Rigidbody playerBody;
    AudioSource rocketThrust;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        rocketThrust = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() 
    {
        
        // Thrust player forward when space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            // Plays thruster audio if it is not playing
            if (!rocketThrust.isPlaying)
            {
                rocketThrust.PlayOneShot(mainEngine);
            }
            // Adds force for thrust
            playerBody.AddRelativeForce(Vector3.up * thrustForceUp * Time.deltaTime);
        }
        else 
        {
            // Stops playing thruster audio when space bar isnt pressed
            rocketThrust.Stop();
        }
    }

    void ProcessRotation()
    {
        // Rotates player left
        if (Input.GetKey(KeyCode.A))
        {
            AddRotationForce(rotationThrust);
        }
        // Rotates player right
        else if (Input.GetKey(KeyCode.D))
        {
            AddRotationForce(-rotationThrust);
        }
    }

    void AddRotationForce(float rotateThisFrame)
    {
        playerBody.freezeRotation = true; // Freezing rotation so we can manually rotate, counteracts bug when hitting obstacle
        transform.Rotate(Vector3.forward * rotateThisFrame * Time.deltaTime);
        playerBody.freezeRotation = false; // Lets physics system take over
    }
}
