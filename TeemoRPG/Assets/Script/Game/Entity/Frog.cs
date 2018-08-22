using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog:Entity
{
    BTRoot AI;
    Vector2 waypoint;
    Delay moveMaxDelay;
    List<Entity> aroundEnemyList = new List<Entity>();
    float searchRadius = 3.5f;
    bool haveWayPoint = false;
    bool isFoundEnemy = false;
    protected override void Start()
    {
        base.Start();
        skillReaderList.Add(new SkillReader(SkillManager.FindSkill("FrogGeneralAttack")));
        BT BTAttack = BT.Sequence
        (
            BT.Call(GeneralAttack)
        );
        BT BTPatrol = BT.Sequence
        (
            BT.Success(BT.Call(RandomWayPoint)),
            BT.Success(BT.Call(FindAroundEnemy)),
            BT.Condition(() => {return !isFoundEnemy;},BT.Call(Move))
        );
        AI = BT.Root
            (
                BT.Sequence
                (
                    BT.Success(BT.Call(FindAroundEnemy)),
                    BT.Selector
                    (
                        BT.Condition(() => {return isFoundEnemy;}, BTAttack),
                        BT.Probability(0.3f * Time.fixedDeltaTime, BTPatrol)
                    )
                )
            );
        moveMaxDelay = new Delay();
    }
    void FixedUpdate()
    {
       AI.Update();
    }
    public BTState GeneralAttack()
    {
        UseSkill(0,aroundEnemyList[0].transform.position,aroundEnemyList[0]);
        return BTState.SUCCESS;
    }
    public BTState RandomWayPoint()
    {
        if(haveWayPoint)
            return BTState.FAILURE;
        waypoint = new Vector2(gameObject.transform.position.x + Random.Range(-3f,3f), gameObject.transform.position.y + Random.Range(-3f,3f));
        moveMaxDelay.Start(3f);  //웨이포인트 유효시간
        haveWayPoint = true;
        return BTState.SUCCESS;
    } 
    public BTState Move()
    {

        if(!haveWayPoint || moveMaxDelay.Check())
        {
            haveWayPoint = false;
            return BTState.FAILURE;
        }

        Vector2 offset = (waypoint - entityRigidbody.position).normalized * speed * Time.deltaTime;
        entityRigidbody.MovePosition(entityRigidbody.position + offset);
        if(((Vector2)gameObject.transform.position - waypoint).sqrMagnitude < 0.5f)
        {
            haveWayPoint = false;
            return BTState.SUCCESS;
        }
        else
            return BTState.CONTINUE;
    }
    public BTState FindAroundEnemy()
    {
        aroundEnemyList = FindEnemyInRadius(searchRadius);
        if(aroundEnemyList.Count == 0)
        {
            isFoundEnemy = false;
            return BTState.FAILURE;
        }
        else
        {
            isFoundEnemy = true;
            return BTState.SUCCESS;
        }
    }
}