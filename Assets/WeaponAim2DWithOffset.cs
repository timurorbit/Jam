using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponAim2DWithOffset : WeaponAim2D
{
    public int type;

    public static Quaternion rotationOriginal;

    protected override void RotateWeapon(Quaternion newRotation, bool forceInstant = false)
    {
        if (type == 0)
        {
            base.RotateWeapon(newRotation, forceInstant);
            rotationOriginal = newRotation;
            return;
        }
        
        if (type == 1)
        {
            base.RotateWeapon(rotationOriginal, forceInstant);
        }

        if (type == 2)
        {
            base.RotateWeapon(rotationOriginal, forceInstant); 
        }

        if (type == 3)
        {
            base.RotateWeapon(rotationOriginal, forceInstant); 
        }
    }
}
