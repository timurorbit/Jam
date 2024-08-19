using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using UnityEngine;

public class PickableWeaponKoalas : PickableWeapon
{
    protected override void Pick(GameObject picker)
    {
       CharacterInventory[] characterInventories = FindObjectsByType<CharacterInventory>(FindObjectsSortMode.None);

       foreach (var VARIABLE in characterInventories)
       { 
           CharacterHandleWeapon handleWeapon = VARIABLE.GetComponent<CharacterHandleWeapon>();
           
           if (handleWeapon)
           {
               handleWeapon.ChangeWeapon(WeaponToGive, WeaponToGive.WeaponID, WeaponToGive.IsComboWeapon);
           }
       }
    }
}
