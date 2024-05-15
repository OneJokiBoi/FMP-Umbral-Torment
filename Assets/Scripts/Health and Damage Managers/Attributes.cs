using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour
{
    public int health;
    public int damage;

    public void TakeDamage(int amount)
    {
        health -= amount;

    }

    public void DealDamage(GameObject target)
    {
        var atm = target.GetComponent<Attributes>();
        if (atm != null)
        {
            atm.TakeDamage(damage);
        }
    }

}
