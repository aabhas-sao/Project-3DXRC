    using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 30f, rotatingSpeed = 8f;

    private GameObject target;
    private Rigidbody enemyRb;
    private Vector3 correctedAxis;
    private bool police = true;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("player");
            return;
        }

        Vector3 pointTarget = transform.position - target.transform.position;
        pointTarget.Normalize();

        float value = Vector3.Cross(pointTarget, transform.up).y;
        enemyRb.angularVelocity = rotatingSpeed * value * new Vector3(0, 1, 0);
        enemyRb.velocity = transform.up * speed;
    }
}
