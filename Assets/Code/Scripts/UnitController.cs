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
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        if (stage == unitStage.idle)
        {
            rb.velocity = (new Vector3(-1.5f, -2, transform.position.z) - transform.position) * Time.deltaTime * 200;
        }
        //if ()
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1);
        stage = unitStage.idle;
    }
}
