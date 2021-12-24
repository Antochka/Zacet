using UnityEngine;

public class Enemy : MonoBehaviour
{
    int Hp = 5;

    public GameObject gun;
    private Vector3 enemyDirection;
    private float rotationAngle;
    private Rigidbody2D rigidbody2D;
    private void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
        enemyDirection = (gameObject.transform.position - gun.transform.position).normalized;
        rotationAngle = Mathf.Atan2(enemyDirection.y, enemyDirection.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        if (rigidbody2D.velocity.magnitude < 0.1f)
        {
            rigidbody2D.AddForce(enemyDirection * -1 * 12);
        }

    }
    public void damage(int dam)
    {
        Hp = Hp - dam;
    }

    private void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(enemyDirection*-1*12);
    }
}
