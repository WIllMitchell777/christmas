using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    Rigidbody RB;
    CapsuleCollider BC;
    PlayerMovement PM;
    GameObject PlayerSpawn;

    void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
        BC = (CapsuleCollider)gameObject.GetComponent("CapsuleCollider");
        PM = (PlayerMovement)gameObject.GetComponent("PlayerController");
        PlayerSpawn = GameObject.FindWithTag("Respawn");
    }

    public void TakeDamage(int Damage, Vector3 Source, bool Knockback)
    {
        if (Health > 0)
        {
            Health -= Damage;
            if (Knockback)
            {
                PM.CanMove = false;
                RB.velocity = new Vector3(0, 0, 0);
                Vector3 DirectionalForce = (transform.position - Source);
                DirectionalForce = new Vector3(Math.Sign(DirectionalForce.x), 1, Math.Sign(DirectionalForce.z));
                RB.velocity = DirectionalForce * 5;
                StartCoroutine(MoveCD());
            }
            if (Health <= 0)
            {
                StartCoroutine(Die());
            }
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
    }

    IEnumerator MoveCD()
    {
        yield return new WaitForSeconds(1f);
        PM.CanMove = true;
    }

    IEnumerator Die()
    {
        PM.CanMove = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        //Send player to game over screen

        //
    }
}
