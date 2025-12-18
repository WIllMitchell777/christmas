using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    public float Yoffset;
    public float Yforce;
    public float Cooldown;
    public GameObject Camera;
    public GameObject SnowballPrefab;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }
    }

    bool AttackCD = false;
    IEnumerator Attack()
    {
        if (AttackCD == false)
        {
            AttackCD = true;
            ////////////spawn snowball////////////
            GameObject NewProjectile = Instantiate(SnowballPrefab);
            NewProjectile.transform.position = gameObject.transform.position + new Vector3(0, Yoffset, 0) + (gameObject.transform.forward);
            NewProjectile.transform.rotation = gameObject.transform.rotation;
            yield return 0;
            ProjectileScript NewProjectileScript = (ProjectileScript)NewProjectile.GetComponent("ProjectileScript");
            StartCoroutine(NewProjectileScript.Fire(Camera.transform.forward,"Enemy",Yforce));
            ///////////////////////////////////
            yield return new WaitForSeconds(Cooldown);
            AttackCD = false;
        }
    }
}
