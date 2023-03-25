using UnityEngine;

public class Hover : MonoBehaviour
{
    public Transform hoverBody;
    public float height = 0.3f;
    public float interval = 1;
    public Vector3 hoverDir = Vector3.up;
    
    public Vector3 startPos;
    
    void Start()
    {
        if(hoverBody != null)
            startPos = hoverBody.localPosition;
    }
    
    void Update()
    {
        if(hoverBody != null)
            hoverBody.localPosition = startPos + hoverDir * Mathf.Sin(Time.time * interval * 6.28f) * height;
    }
}
