using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Fire : MonoBehaviour 
{
    private Vector3 cursorPosition = new Vector2(0, 0);
    private Vector3 cursorDirection = new Vector2(0, 0);
    public float rotationAngle = 0.1f;
    public GameObject FirePoint;
    private GameObject EnemyO;
    private Enemy enemyS;
    public Text text;
    private Animator animator;
    private int points = 0;
    public Text pointsText;
    private void Start()
    {
        text.text = "";
        animator = gameObject.GetComponent<Animator>();
        pointsText.text = "Счет: 0";
    }

    IEnumerator TimerFire(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("isFire", false);
    }
    private void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0;
        cursorDirection = (cursorPosition - gameObject.transform.position).normalized;
        rotationAngle = Mathf.Atan2(cursorDirection.y, cursorDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit2D hit;
            hit = Physics2D.Raycast(FirePoint.transform.position, FirePoint.transform.right);
            animator.SetBool("isFire", true);
            StartCoroutine(TimerFire(0.2f));
            if (hit.collider != null)
            {   
                Debug.DrawLine(FirePoint.transform.position, hit.point, Color.green);
                Debug.Log("Поподание");
                EnemyO = hit.collider.gameObject;
                enemyS = EnemyO.GetComponent<Enemy>();
                enemyS.damage(2);
                points = points + 100;
                pointsText.text = "Счет: " + points;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy")
        {
            text.text = "Game Over";
            StartCoroutine(Timer(3));
        }
    }
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("SampleScene");
    }
}
