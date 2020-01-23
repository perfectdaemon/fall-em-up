using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public GameObject BackgroundBlock;

    public GameObject Player;

    public GameObject Pickup;

    public List<Sprite> PickupSprites;

    private readonly List<GameObject> backgroundBlocks = new List<GameObject>();

    private float disappearRange = 10;

    private Vector3 previousPosition;

    private float minimumY;

    private float chanceToCreatePickup = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = BackgroundBlock.transform.position;
        minimumY = Player.transform.position.y;

        for (int i = 0; i < 10; ++i)
        {
            var block = GameObject.Instantiate(BackgroundBlock, GetNewPosition(), Quaternion.identity);
            backgroundBlocks.Add(block);

            CreatePickup(block.transform.position);
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

                CreatePickup(block.transform.position);
            }
        }
    }

    private void CreatePickup(Vector3 blockPosition)
    {
        var roll = Random.value;
        if (roll < chanceToCreatePickup)
        {
            var pickupPosition = blockPosition + new Vector3(Random.Range(-2, 2), Random.Range(1, 3));
            var pickup = GameObject.Instantiate(Pickup, pickupPosition, Quaternion.identity);

            var spriteIndex = Random.Range(0, PickupSprites.Count - 1);

            pickup.GetComponent<SpriteRenderer>().sprite = PickupSprites[spriteIndex];
        }
    }

    private Vector3 GetNewPosition()
    {
        var position = new Vector3(previousPosition.x + Random.Range(5.5f, 7.0f), previousPosition.y + Random.Range(-1.5f, 1.5f), previousPosition.z);
        previousPosition = position;
        if (position.y < minimumY)
        {
            minimumY = position.y;
            Player.GetComponent<PlayerController>().DeathHeight = minimumY - 5;
        }

        return position;
    }
}
