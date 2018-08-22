using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerContoller : MonoBehaviour
{
    
    public Player player;
    Rigidbody2D playerRigidbody;
    void OnEnable()
    {
        if(playerRigidbody == null)
            playerRigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
       MoveUpdate();
       UIUpdate();
    }
    void MoveUpdate()
    {
        Vector2 dir = Vector2.zero;
        if(Input.GetKey(KeyCode.A))
        {
           dir += Vector2.left;
        }
        if(Input.GetKey(KeyCode.D))
        {
            dir += Vector2.right;
        }
        if(Input.GetKey(KeyCode.W))
        {
           dir += Vector2.up;
        }
        if(Input.GetKey(KeyCode.S))
        {
            dir += Vector2.down;
        }
        if(Input.GetMouseButtonDown(0))
        {
            player.UseSkill(4, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), null);
        }
        dir.Normalize();
        playerRigidbody.MovePosition(playerRigidbody.position +  dir * player.speed  * Time.deltaTime);
    }
    void UIUpdate()
    {
        if(UIManager.instance == null)
            return;
        UIManager uiManger = UIManager.instance;
        uiManger.hpBar.maxValue = player.maxHp;
        uiManger.hpBar.value = player.hp;
        uiManger.mpBar.maxValue = player.maxMp;
        uiManger.mpBar.value = player.mp;

        for(int i = 0;i < 6; i++)
        {
            player.GetSkillReader(i).delay.Update();
            if(player.GetSkillReader(i).delay.delay == 0)
                uiManger.GetUISkill(i).cooltime = 0;
            else
                uiManger.GetUISkill(i).cooltime = 1f - Mathf.Min(1f,player.GetSkillReader(i).delay.elapsedTime / player.GetSkillReader(i).delay.delay);
        }
    }
}