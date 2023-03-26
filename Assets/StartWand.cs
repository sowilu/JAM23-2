using UnityEngine;

public class StartWand : MonoBehaviour
{
    public GameObject particles;
    public AudioClip sound;
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.CompareTag("Player"))
        {
            Instantiate( particles, transform.position, Quaternion.identity );
            Audio.Play(sound);
            Player.inst.gameObject.GetComponent<Wand>().enabled = true;
            GameManager.onGameStart.Invoke();
            
            Destroy(gameObject);
        }
    }
}
