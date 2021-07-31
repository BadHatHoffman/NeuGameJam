using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public Spell spellObj;

    public void CastSpell()
    {
        print("Heloooooooooooo");
        spellObj.rb.AddForce(Vector3.forward * spellObj.speed);
        spellObj.transform.parent = null;
    }
}
