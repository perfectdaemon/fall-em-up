using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject BackgroundBlock;

    public Transform Player;

    private readonly List<GameObject> backgroundBlocks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        var previousPosition = Player.position;
        for (int i = 0; i < 20; ++i)
        {
            var position = new Vector3(previousPosition.x + Random.Range(3, 6), previousPosition.y + Random.Range(-2, 2), previousPosition.z);
            var block = GameObject.Instantiate(BackgroundBlock, position, Quaternion.identity);
            backgroundBlocks.Add(block);
            previousPosition = position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
