using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Vector3 targetDir;

    [Header("Jumping")] public float gravity = 10;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = targetDir * speed;
        
        //if player isnt rotated towards targetDir, rotate towards it
        if (Vector3.Angle(transform.forward, targetDir) > 1)
        {
            transform.forward = Vector3.Lerp(transform.forward, targetDir, 0.1f);
        }
    }

    public void Move(Vector2 direction)
    {
        targetDir = direction.X0Y();
    }
    
    float HeightToVelocity( float height) => Mathf.Sqrt( 2 * gravity * height );
}
