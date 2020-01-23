using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject BackgroundBlock;

    public GameObject Player;

    private readonly List<GameObject> backgroundBlocks = new List<GameObject>();

    private float disappearRange = 10;

    private Vector3 previousPosition;

    private float minimumY;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = BackgroundBlock.transform.position;
        minimumY = Player.transform.position.y;

        for (int i = 0; i < 10; ++i)
        {
            var block = GameObject.Instantiate(BackgroundBlock, GetNewPosition(), Quaternion.identity);
            backgroundBlocks.Add(block);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var block in backgroundBlocks)
        {
            if (Player.transform.position.x - block.transform.position.x > disappearRange)
            {
                block.transform.position = GetNewPosition();
            }
        }
    }

    private Vector3 GetNewPosition()
    {
        var position = new Vector3(previousPosition.x + Random.Range(5.5f, 7.7f), previousPosition.y + Random.Range(-2.0f, 2.0f), previousPosition.z);
        previousPosition = position;
        if (position.y < minimumY)
        {
            minimumY = position.y;
            Player.GetComponent<PlayerController>().DeathHeight = minimumY - 5;
        }
            
        return position;
    }
}
