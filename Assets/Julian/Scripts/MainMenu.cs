using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Main Scene");
        audioSource.PlayOneShot(buttonSound, 1f);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions");
        audioSource.PlayOneShot(buttonSound, 1f);

    }
}
