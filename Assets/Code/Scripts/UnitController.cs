using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public unitStage stage = unitStage.spawn;

    public enum unitStage {spawn, idle, fight};

    private Vector3 wanderPoint;
    private Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(Spawning());
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        if (stage == unitStage.idle)
        {
            if(wanderPoint == null || (wanderPoint.x == transform.position.x && wanderPoint.y == transform.position.y))
            {
                wanderPoint = new Vector2(transform.position.x + Random.Range(-0.5f, 0.5f), transform.position.y + Random.Range(-0.5f, 0.5f));
            }
            rb.velocity = (wanderPoint - transform.position) * Time.deltaTime * 0.2f;
        }
        //if ()
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1);
        stage = unitStage.idle;
    }
}
