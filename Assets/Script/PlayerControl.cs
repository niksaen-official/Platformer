using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator animator;
    public LayerMask ground;
    public Transform groundCheck;
    public Transform attackCheck;
    public int moveSpeed = 8;
    public int jumpSpeed = 4;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    public void Move(float direction)
    {
        animator.SetBool("isMove", direction != 0);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x+(direction * moveSpeed*Time.deltaTime), gameObject.transform.position.y, gameObject.transform.position.z);
        Flip(direction);
    }
    public void Jump()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, 0.25f, ground))
        {
            animator.SetBool("isJump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpSpeed * 100);
            StartCoroutine(jumpEnd());
        }
        
    }
    public void Attack()
    {
        animator.SetBool("isAttack", true);
        StartCoroutine(attackEnd());
        GameObject entity = Physics2D.OverlapBox(attackCheck.position, new(0.5f, 1), 0).gameObject;
        if (entity.GetComponent<Entity>() != null)
        {
            entity.GetComponent<Entity>().Kill();
            PlayerData.AddKill();
        }
    }


    private void Flip(float direction)
    {
        if (direction != 0)
        {
            if (direction > 0) gameObject.transform.localScale = new(3, 3, 3);
            else gameObject.transform.localScale = new(-3, 3, 3);
        }
    }
    private IEnumerator jumpEnd()
    {
        yield return new WaitForSeconds(0.4f);
        animator.SetBool("isJump", false);
    }
    private IEnumerator attackEnd()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("isAttack", false);
    }
}
