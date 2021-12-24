using System.Collections;
using UnityEngine;

public class Spavn : MonoBehaviour
{
    public GameObject enemy;
    bool timer = false;
    private void FixedUpdate()
    {
        if(timer == false)
        {
            StartCoroutine(TimerFire(4f));
            timer = true;
            Vector3 position = new Vector3(Random.Range(2.0f, 5.0f)* Random.Range(-1.0f, 1.0f), Random.Range(2.0f, 5.0f)* Random.Range(-1.0f, 1.0f), 0);
            Instantiate(enemy, position, Quaternion.identity);
            Debug.Log("Спавн");
        }
    }
    IEnumerator TimerFire(float time)
    {
        yield return new WaitForSeconds(time);
        timer = false;
    }
}
