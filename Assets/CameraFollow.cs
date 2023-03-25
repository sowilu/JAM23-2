using UnityEngine;

[ExecuteAlways]
public class CameraFollow : UnitySingleton<CameraFollow>
{
    public Transform target;
    
    [Header("Zoom")]
    public float minZoom = 2f;
    public float maxZoom = 7f;

    private float targetZoom;
    [Range(0,1)]public float zoomSmoothness = 0.9f;

    [Range(0f,1f)]public float zoom = 0;
    private Camera cam;
    
    void Start()
    {
        cam = Camera.main;
    }
    
    
    
    private void LateUpdate()
    {
        if(target == null)return;

        transform.position = target.position;

        Zooming();
    }
    
    
    private void Zooming()
    {
        if(cam == null)return;
        
        //orth size is the zoom
        targetZoom = Mathf.Lerp(minZoom, maxZoom, zoom);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, 1- zoomSmoothness);
    }
}
