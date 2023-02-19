using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project.Managers;

public class SnailChaseComponent : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Rigidbody2D collisionRb;

    [SerializeField]
    float power;

    public GameObject ClosestPlayer
    {
        get;
        set;
    }

    public float ClosestPlayerDistance
    {
        get;
        set;
    } = 99999;

    public void Start()
    {
        InvokeRepeating("FindClosestPlayer", 0, 0.3f);
    }

    public void FixedUpdate()
    {
        MoveTowardsClosetPlayer();
    }


    private void FindClosestPlayer()
    {
        if (PlayerManager.Instance == null)
        {
            return;
        }

        ClosestPlayerDistance = 9999;

        for (int i = 0; i < PlayerManager.Instance.players.Count; i++)
        {
            if(PlayerManager.Instance.players[i] == null)
            {
                return;
            }
            float distance = Vector3.Distance(transform.position, PlayerManager.Instance.players[i].transform.position);
            if (distance <= ClosestPlayerDistance)
            {
                ClosestPlayerDistance = distance;
                ClosestPlayer = PlayerManager.Instance.players[i];
            }
        }
    }

    private void MoveTowardsClosetPlayer()
    {
        if(ClosestPlayer == null)
        {
            return;
        }
        if (ClosestPlayer.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(new Vector2(moveSpeed, 0));
        } else if (ClosestPlayer.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(new Vector2(-moveSpeed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if(collisionRb == null)
        {
            return;
        }
        Vector2 direction = (transform.position - collision.gameObject.transform.position).normalized;
        collisionRb.AddForce(-direction * power);

    }
}
