
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float minTurnSpeed = 45f;
    public float maxTurnSpeed = 180f;

    private float turnSpeed;
    private Vector3 rotationAxis;

    private void Start()
    {
       
        turnSpeed = Random.Range(minTurnSpeed, maxTurnSpeed);

        
        rotationAxis = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ).normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name != "Player")
        {
            return;
        }
        GameManager.instance.IncremetScore();
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(rotationAxis * turnSpeed * Time.deltaTime);
    }
}