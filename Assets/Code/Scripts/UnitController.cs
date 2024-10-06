using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public int hp = 10;
    public unitStage stage = unitStage.spawn;

    public enum unitStage {spawn, idle, fight, dead};

    private Vector3 wanderPoint;
    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        StartCoroutine(Spawning());
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        if (stage == unitStage.idle)
        {
            rb.velocity = new Vector2(-1.5f - transform.position.x, -2f - transform.position.y) * Time.deltaTime * 50;
        }
        else if(stage == unitStage.spawn || stage == unitStage.dead)
        {
            rb.velocity = Vector2.left * Time.deltaTime * 50;
        }
        if (transform.position.x < -3)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Spawning()
    {
        yield return new WaitForSeconds(1);
        stage = unitStage.idle;
    }

    public void Damage(int val)
    {
        hp -= val;
        if (hp <= 0)
        {
            stage = unitStage.dead;
            animator.SetTrigger("death");
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
