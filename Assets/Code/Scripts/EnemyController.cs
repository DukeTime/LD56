using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hp = 150;
    public int dmg = 15;
    public int speed = 60;
    public float couldown = 0.5f;

    public enemyStage stage = enemyStage.idle;
    public enum enemyStage {idle, fight};

    private Rigidbody2D rb;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (stage == enemyStage.idle)
        {
            rb.velocity = Vector3.left * Time.deltaTime * speed;
        }
    }
    private IEnumerator Fight(UnitController unit)
    {
        yield return new WaitForSeconds(couldown);
        animator.SetTrigger("punch");
        yield return new WaitForSeconds(0.5f);
        if (unit != null)
        {
            unit.Damage(dmg);
            if (unit.stage == UnitController.unitStage.dead)
            {
                StopCoroutine(Fight(unit));
                stage = enemyStage.idle;
            }
                
        }
        animator.ResetTrigger("punch");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (stage == enemyStage.idle)
            if (collision.gameObject.GetComponent<UnitController>() != null)
                StartCoroutine(Fight(collision.gameObject.GetComponent<UnitController>()));
    }
}
