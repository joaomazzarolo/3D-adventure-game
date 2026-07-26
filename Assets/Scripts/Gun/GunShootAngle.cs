using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShootAngle : GunShootLimit
{
    public int amountPerShot = 4;
    public float angle = 15f;

    public override void Shoot()
    {
        int mult = 0;

        for (int i = 0; i < amountPerShot; i++)
        {
            if (i % 2 == 0)
            {
                mult++;
            }
            var projectile = Instantiate(prefabProjectile, positionToShoot);

            projectile.transform.position = positionToShoot.position;
            projectile.transform.rotation = positionToShoot.rotation;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i % 2 == 0 ? angle : -angle) * mult;

            projectile.speed = speed;
            projectile.transform.parent = null;
        }

    }
}
