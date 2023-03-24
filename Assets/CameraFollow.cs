using UnityEngine;

[ExecuteAlways]
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    
    private void LateUpdate()
    {
        if(target == null)return;

        transform.position = target.position;
    }
}
