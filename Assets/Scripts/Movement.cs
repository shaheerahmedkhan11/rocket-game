using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float Thrust = 100f;

    [SerializeField]
    private float Rotationthrust;

    private Rigidbody rb;
    AudioSource audioSource;
    [SerializeField]
    AudioClip mainEngine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rocket_Thrust();
        Rocket_Rotation();
    }

    private void Rocket_Thrust()
    {

        if (Input.GetKey(KeyCode.K))
        {
            rb.AddRelativeForce(Thrust * Time.deltaTime * Vector3.up);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }

        }
        else
        {
            audioSource.Stop();
        }
       
    }
    private void Rocket_Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Apply_Rotation_Forwards(Rotationthrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            Apply_Rotation_Backwards(Rotationthrust);
        }
    }
    private void Apply_Rotation_Forwards(float rotationSpeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);
        rb.freezeRotation = false;
    }
    private void Apply_Rotation_Backwards(float rotationSpeed)
    {
        rb.freezeRotation = true;
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.back);
        rb.freezeRotation = false;
    }
}
