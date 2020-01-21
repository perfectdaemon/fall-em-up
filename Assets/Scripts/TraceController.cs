using UnityEngine;

[RequireComponent(typeof(Transform))]
public class TraceController : MonoBehaviour
{
    public bool LockY;

    public Transform FollowIt;

    private Transform selfTransform;

    // Start is called before the first frame update
    void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position = new Vector3(
            FollowIt.position.x,
            LockY
                ? selfTransform.position.y
                : FollowIt.position.y,
            selfTransform.position.z
        );
    }
}
