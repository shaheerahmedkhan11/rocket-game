using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("You have picked up fuel.");
                break;
            case "friendly":
                Debug.Log("This object is friendly");break;
            case "Finish":
                Debug.Log("Congrats! You have reached the finish point!");
                Load_Next_Level();
                break;
            default:
                Debug.Log("Out of bounds!You blew up");
                Invoke("Reload_Level", 2f);
                break;

        }
    }
    void Load_Next_Level()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
    void Reload_Level()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
