using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip mcRide; //lol 

    private void OnTriggerEnter(Collider other)
    {
        gameManager.OnGoalTrigger(this);

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = mcRide;
        audioSource.Play();
    }
}
