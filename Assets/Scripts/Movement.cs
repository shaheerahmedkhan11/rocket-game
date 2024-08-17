using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float Thrust = 100f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        }
    }
    private void Rocket_Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            print("Keycode A pressed - Rotating left");
        }

        else if (Input.GetKey(KeyCode.D))
        {
            print("Keycode A pressed - Rotating right");
        }
    }
}
