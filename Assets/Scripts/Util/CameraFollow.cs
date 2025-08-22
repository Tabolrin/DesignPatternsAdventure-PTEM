using UnityEngine;

public class SimpleCameraFollow2D : MonoBehaviour
{
    [SerializeField] private Transform target;   
    [SerializeField] private Collider2D mapBounds;
    [SerializeField] private Camera cam;

    void Start()
    {
        if (cam == null)
            cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (!target) return;
        
        Vector3 pos = target.position;
        pos.z = transform.position.z;
        
        float halfH = cam.orthographicSize;
        float halfW = cam.aspect * halfH;

        Bounds b = mapBounds.bounds;
        pos.x = Mathf.Clamp(pos.x, b.min.x + halfW, b.max.x - halfW);
        pos.y = Mathf.Clamp(pos.y, b.min.y + halfH, b.max.y - halfH);

        transform.position = pos;
    }
}