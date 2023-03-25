using UnityEngine;

public class Hover : MonoBehaviour
{
    public float height = 0.3f;
    public float interval = 1;
    
    public Vector3 startPos;
    
    void Start()
    {
        startPos = transform.localPosition;
    }
    
    void Update()
    {
        transform.localPosition = startPos + new Vector3(0, Mathf.Sin(Time.time * interval * 6.28f) * height, 0);
    }
}
