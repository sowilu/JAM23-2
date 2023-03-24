using UnityEngine;

public class BlobShadow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        if(target == null)
        {
            target = transform.parent;
        }

        transform.parent = null;
        transform.rotation = Quaternion.Euler(90,0,0);
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        var targetPos =  target.position;
        targetPos.y = 0.01f;
        transform.position = targetPos;
    }
}
