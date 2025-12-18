using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSnowball : MonoBehaviour
{
    public float Cooldown;
    public GameObject Camera;
    public GameObject SnowballPrefab;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(AttackBow());
        }
    }

    bool AttackCD = false;
    IEnumerator AttackBow()
    {
        if (AttackCD == false)
        {
            AttackCD = true;
            ////////////spawn snowball////////////
            GameObject NewProjectile = Instantiate(SnowballPrefab);
            NewProjectile.transform.position = gameObject.transform.position + new Vector3(0, 1, 0) + (gameObject.transform.forward);
            NewProjectile.transform.rotation = gameObject.transform.rotation;
            yield return 0;
            ProjectileScript NewProjectileScript = (ProjectileScript)NewProjectile.GetComponent("ProjectileScript");
            NewProjectileScript.Fire(Camera.transform.forward);
            ///////////////////////////////////
            yield return new WaitForSeconds(Cooldown);
            AttackCD = false;
        }
    }
}
