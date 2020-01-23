using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float ConstantMoveVelocity;

    public float JumpVelocity;

    public Transform GroundChecker;

    public float GroundRadius;

    public float DeathHeight;

    public LayerMask GroundLayer;

    public GameObject EndGameMenu;

    public int Score;

    public GameObject ScoreText;

    public GameObject FinalScoreText;

    private Rigidbody2D rb;

    private bool isOnGround;

    private bool isAlive;

    void Start()
    {
        EndGameMenu.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
        rb.simulated = true;
        StartCoroutine(AddScore());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < DeathHeight)
        {
            isAlive = false;
            rb.simulated = false;
            EndGameMenu.SetActive(true);
            FinalScoreText.GetComponent<Text>().text = Score.ToString();
        }

        if (!isAlive)
            return;

        rb.velocity = new Vector2(ConstantMoveVelocity, rb.velocity.y);

        isOnGround = Physics2D.OverlapCircle(GroundChecker.position, GroundRadius, GroundLayer);

        if (isOnGround && Input.GetMouseButtonDown(0))
            rb.velocity += new Vector2(0, JumpVelocity);

        AddScore();
    }

    IEnumerator AddScore()
    {
        while (isAlive)
        {
            Score += 1;
            ScoreText.GetComponent<Text>().text = Score.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
