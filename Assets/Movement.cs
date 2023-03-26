using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Vector3 targetDir;
    public float rotateSpeed = 720;

    [Header("Jumping")] public float gravity = 10;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = targetDir * speed;
        
        transform.forward = Vector3.RotateTowards( transform.forward, targetDir, Mathf.Deg2Rad * rotateSpeed * Time.deltaTime, 0.0f);

        if (targetDir != Vector3.zero)
        {
            // jumpy movement animation
            // if on grond, then jump
            var grounded = Physics.Raycast(transform.position, Vector3.down, 1f);
            if (grounded)
            {
                rb.velocity += Vector3.up * gravity;
            }
        }
    }

    public void Move(Vector2 direction)
    {
        targetDir = direction.X0Y();
    }
    
    float HeightToVelocity( float height) => Mathf.Sqrt( 2 * gravity * height );
}
