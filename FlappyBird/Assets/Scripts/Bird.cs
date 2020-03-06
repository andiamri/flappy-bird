using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 300;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnDead, OnJump;
    [SerializeField] private int score = 0;
    [SerializeField] private UnityEvent OnAddPoint;

    public Text scoreText;

    private Animator anim;
    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        
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
            anim.enabled = false;
        }
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
        Dead();
        anim.enabled = false;
    }
    public void AddScore(int value)
    {
        score += value;

        if(OnAddPoint != null)
        {
            OnAddPoint.Invoke();
        }
        scoreText.text = score.ToString();
        Debug.Log(score);
    }
}
