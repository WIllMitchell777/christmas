using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int Health;
    Rigidbody RB;

    void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
    }

    public void TakeDamage(int Damage, Vector3 Source, bool Knockback, float Force)
    {
        Health -= Damage;
        if (Knockback)
        {
            RB.velocity = new Vector3(0, 0, 0);
            Vector3 DirectionalForce = (transform.position - Source);
            DirectionalForce = new Vector3(Math.Sign(DirectionalForce.x), 1, Math.Sign(DirectionalForce.z));
            RB.velocity = DirectionalForce * Math.Abs(Force);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
