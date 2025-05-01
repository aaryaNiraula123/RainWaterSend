using UnityEngine;

public class AnimalMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRadius = 5f;
    public float waitTime = 3f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private float waitTimer;

    void Start()
    {
        startPos = transform.position;
        PickNewTarget();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

            // Optional: Face movement direction
            Vector3 direction = (targetPos - transform.position).normalized;
            if (direction != Vector3.zero)
                transform.forward = direction;
        }
        else
        {
            // Wait before picking a new target
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                PickNewTarget();
            }
        }
    }

    void PickNewTarget()
    {
        Vector2 randomCircle = Random.insideUnitCircle * moveRadius;
        targetPos = startPos + new Vector3(randomCircle.x, 0f, randomCircle.y);
    }
}
