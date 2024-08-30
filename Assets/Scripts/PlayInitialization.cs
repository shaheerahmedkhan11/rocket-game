using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayInitialization : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Level 1");
    }
}
