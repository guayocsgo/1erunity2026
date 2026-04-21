
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5f;
    public Rigidbody rb;

    public float laneWidth = 3f;
    private int currentLane = 1;
    private float targetX;
    public float laneChangeSpeed = 10f;
    private bool canChangeLane = true;

    private Animator animator;

    private void Start()
    {
        targetX = transform.position.x;
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (!alive) return;
        HandleLaneInput();
        if (transform.position.y < -5f)
            Die();
    }

    private void HandleLaneInput()
    {
        bool moveLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        bool moveRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (moveLeft && canChangeLane && currentLane > 0)
        {
            currentLane--;
            UpdateTargetX();
        }
        else if (moveRight && canChangeLane && currentLane < 2)
        {
            currentLane++;
            UpdateTargetX();
        }
    }

    private void UpdateTargetX()
    {
        float originX = 0f;
        targetX = originX + (currentLane - 1) * laneWidth;
    }

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        float newX = Mathf.Lerp(rb.position.x, targetX, laneChangeSpeed * Time.fixedDeltaTime);
        Vector3 newPosition = new Vector3(newX, rb.position.y, rb.position.z + forwardMove.z);
        rb.MovePosition(newPosition);
    }

    public void Die()
    {
        alive = false;
        if (animator != null) animator.enabled = false;
        Invoke("ShowGameOver", 0f); 
    }

    void ShowGameOver()
    {
        GameManager.instance.ShowGameOver();
    }
}