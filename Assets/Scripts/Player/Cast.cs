using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Spell spellObj;

    public void CastSpell()
    {
        spellObj.transform.rotation = spellObj.transform.parent.rotation;

        Vector3 towardsSpot = Vector3.forward;

        foreach (var item in Physics.RaycastAll(transform.position, Vector3.forward))
        {
            if(item.transform.gameObject.CompareTag("Enemy"))
            {
                towardsSpot = item.transform.position;

                break;
            }
        }

        spellObj.rb.AddForce((towardsSpot - transform.position) * spellObj.speed);
        
        
        
        spellObj.transform.parent = null;
        spellObj.damage = GetComponentInParent<MainController>().damage;
    }
}
