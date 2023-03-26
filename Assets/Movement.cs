using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Vector3 targetDir;
    public float rotateSpeed = 720;
    public Transform visuals;

    [Header("Jumping")] public float gravity = 10;
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public float jumpTime = 0.5f;
    public float jumpTimeLeft = 0;

    private void Update()
    {
        rb.velocity = targetDir * speed;
        
        transform.forward = Vector3.RotateTowards( transform.forward, targetDir, Mathf.Deg2Rad * rotateSpeed * Time.deltaTime, 0.0f);

        
        // jumping
        jumpTimeLeft -= Time.deltaTime;
        if (targetDir != Vector3.zero)
        {
            if (jumpTimeLeft <= 0)
            {
                jumpTimeLeft = jumpTime;
            }
            
            // visuals jump(bunnyhop) animation
        }
        
        var t = jumpTimeLeft / jumpTime;
        t = Mathf.Clamp01(t);
        visuals.transform.localPosition = Mathf.Abs(Mathf.Sin(t * 3.14f)) * Vector3.up * 0.5f;
    }

    public void Move(Vector2 direction)
    {
        targetDir = direction.X0Y();
    }
    
    float HeightToVelocity( float height) => Mathf.Sqrt( 2 * gravity * height );
}
