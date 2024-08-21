using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("You have picked up fuel.");break;
            case "friendly":
                Debug.Log("This object is friendly");break;
            case "Finish":
                Debug.Log("Congrats! You have reached the finish point!");break;
            default:
                Debug.Log("Out of bounds!You blew up"); break;

        }
    }
}
