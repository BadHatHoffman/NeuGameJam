using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Spell spellObj;

    public void CastSpell()
    {
        spellObj.transform.rotation = spellObj.transform.parent.rotation;


        spellObj.rb.AddForce(GetComponentInParent<MainController>().transform.forward * spellObj.speed);
        
        spellObj.transform.parent = null;
        spellObj.damage = GetComponentInParent<MainController>().damage;
    }
}
