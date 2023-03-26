using UnityEngine;

public class StartWand : MonoBehaviour
{
    public GameObject particles;
    public AudioClip sound;
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Player"))
        {
            GameManager.onGameStart.Invoke();
            Instantiate( particles, transform.position, Quaternion.identity );
            Audio.Play(sound);
            Destroy(gameObject);
        }
    }
}
