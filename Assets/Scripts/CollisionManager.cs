using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionManager : MonoBehaviour
{
    bool isTransitioning = false;

    [SerializeField] ParticleSystem explosion_particles1;
    [SerializeField] ParticleSystem explosion_particles2;
    [SerializeField] ParticleSystem explosion_particles3;
    [SerializeField] ParticleSystem success_particles;
    [SerializeField] private float DelayInReload = 2f;
    [SerializeField] AudioClip Death, Success;
    AudioSource audio_source;

    private void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning == false)
        {
            switch (collision.gameObject.tag)
            {
                case "friendly":
                    Debug.Log("This object is friendly"); break;
                case "Finish":
                    Debug.Log("Congrats! You have reached the finish point!");
                    StartSuccessSequence();
                    break;
                default:
                    Debug.Log("Out of bounds!You blew up");
                    StartCrashSequence();
                    break;
            }
        }
       
    }
    void StartCrashSequence()
    {
        isTransitioning = true;
        audio_source.Stop();
        audio_source.PlayOneShot(Death);
        explosion_particles1.Play();
        explosion_particles2.Play();
        explosion_particles3.Play();
        success_particles.Play();
        Invoke("Reload_Level", DelayInReload);
        GetComponent<Movement>().enabled = false;
        
    }
    void StartSuccessSequence()
    {
        isTransitioning = true;
        audio_source.Stop();
        audio_source.PlayOneShot(Success);
        Invoke("Load_Next_Level", DelayInReload);
        GetComponent<Movement>().enabled = false;
        
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
