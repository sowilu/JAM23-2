using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;
    public string targetTag = "Player";


    private void Update()
    {
        // target closest in overlap sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(targetTag))
            {
                Debug.Log("Target found");
            }
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.up, range);
    }
#endif
}