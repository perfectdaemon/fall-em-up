using UnityEngine;

[RequireComponent(typeof(Transform))]
public class TraceController : MonoBehaviour
{
    public Transform FollowIt;

    public Vector3 Offset;

    public float SmoothTime;

    private Transform selfTransform;

    private Vector2 velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var targetPosition = FollowIt.position + Offset;
        var smoothPosition = Vector2.SmoothDamp(selfTransform.position, targetPosition, ref velocity, SmoothTime);
        selfTransform.position = new Vector3(smoothPosition.x, smoothPosition.y, selfTransform.position.z);
    }
}
