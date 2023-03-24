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
    }

    public void Move(Vector2 direction)
    {
        targetDir = direction.X0Y();
    }
    
    float HeightToVelocity( float height) => Mathf.Sqrt( 2 * gravity * height );
}
