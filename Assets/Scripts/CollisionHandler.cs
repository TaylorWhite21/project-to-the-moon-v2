using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{ 
    // Sets delay for loading next level or reloading current level
    [SerializeField] float delayReloadLevel = 3f;
    [SerializeField] float delayLoadNextLevel = 3f;

    [SerializeField] AudioClip success;
    [SerializeField] AudioClip playerExplosion;

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
        {
            switch (other.gameObject.tag)
            {
                case "Friendly":
                    print("Nothing happens");
                    break;
                case "Finish":
                    print("WooHoo you won!");
                    StartPlayerSuccess();
                    break;
                default:
                    print("You died =(");
                    StartPlayerDeathSequence();
                    break;
            }
        }
    
    void StartPlayerDeathSequence()
    {
        GetComponent<Movement>().enabled = false;
       audioSource.PlayOneShot(playerExplosion);
        Invoke("ReloadLevel", delayReloadLevel);
    }

    void StartPlayerSuccess()
    {
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(success);
        Invoke("LoadNextLevel", delayLoadNextLevel);
    }
    // Reloads current level
    void ReloadLevel()
    {   
        // Saves current level index
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    void LoadNextLevel()
    {   
        // Saves current level index
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        // Increments level index by 1
        int nextLevelIndex = currentLevel + 1;
        // If you are on the last level, then set level index to first level (0)
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        // Loads level
        SceneManager.LoadScene(nextLevelIndex);

    }
}
