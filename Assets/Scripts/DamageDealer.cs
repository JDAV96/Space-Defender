using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageOnContact = 1;

    public int GetDamageDealt()
    {
        return damageOnContact;
    }
}
