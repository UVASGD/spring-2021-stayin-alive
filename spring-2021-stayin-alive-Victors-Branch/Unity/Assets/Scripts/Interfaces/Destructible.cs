using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Interactable {

    public virtual void TakeDamage() {}

    public virtual void Die() {}

    public virtual void Heal(){}

}
