using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting:MonoBehaviour
{
    public Player player; 
    public void Awake()
    {
        GameManager.player = player;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Entity"),LayerMask.NameToLayer("Entity"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Damager"),LayerMask.NameToLayer("Damager"));
    }
}