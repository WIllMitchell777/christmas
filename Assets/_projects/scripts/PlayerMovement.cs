using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpPower;
    public bool CanMove;
    public PhysicMaterial PsM;
    bool Grounded = true;
    Transform GroundChecker;
    Rigidbody RB;
    void Start()
    {
        RB = (Rigidbody)gameObject.GetComponent("Rigidbody");
        GroundChecker = (Transform)GameObject.FindWithTag("GroundChecker").GetComponent("Transform");
    }

    void Update()
    {
        if (CanMove == true)
        {
            float MovementInputLR = Input.GetAxis("Horizontal");
            float MovementInputFB = Input.GetAxis("Vertical");

            if (MovementInputLR != 0 || MovementInputFB != 0)
            {
                PsM.dynamicFriction = 0f;
                Vector3 direction = new Vector3(MovementInputLR, 0, MovementInputFB);
                direction = RB.rotation * direction;

                RB.velocity = new Vector3(direction.x * MoveSpeed, RB.velocity.y, direction.z * MoveSpeed);
            }
            else
            {
                PsM.dynamicFriction = 0.6f;
            }

            if (Input.GetKey(KeyCode.Space) && Grounded == true)
            {
                Grounded = false;
                RB.velocity = new Vector3(RB.velocity.x, JumpPower, RB.velocity.z);
            }
        }

        CheckGround();
    }

    private void CheckGround()
    {
        Collider[] colliders = Physics.OverlapBox(GroundChecker.position, GroundChecker.localScale);
        bool Found = false;
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag != "Player") //Change to collider.tag == "JumpAllowed" if you want to only have specific parts be jumpable on (give them the JumpAllowed tag)
            {
                Found = true;
                break;
            }
        }
        if (Found == true)
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }
}
