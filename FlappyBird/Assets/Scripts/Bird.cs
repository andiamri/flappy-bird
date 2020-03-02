using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;

    private Rigidbody2D rigid;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead && Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;        }
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void Dead()
    {
        if(!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }
        isDead = true;
    }
    public void Jump()
    {
        if (rigid)
        {
            rigid.velocity = Vector2.zero;

            rigid.AddForce(new Vector2(0, upForce));
        }
        if(OnJump != null)
        {
            OnJump.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.enabled = false;
        Dead();
    }
}
