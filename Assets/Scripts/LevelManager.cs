using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class LevelManager : GameSingleActor<LevelManager>
{
    public int specialEnemyCount;
    public List<Transform> enemyPoints;
    public List<GateActor> allGates;
    private int doorIndexer = 0;

    public override void ActorStart()
    {
    
        CreateEnemy();
    }
    private void CreateEnemy()
    {
         int enemyIndexer = 0;
         Shuffle(enemyPoints);
         Shuffle(allGates);

        GameObject enemy= GameData.Instance.enemy;
        for (int i = 0; i < specialEnemyCount; i++)
        {
            Transform point = enemyPoints[enemyIndexer];
            if(enemyIndexer>=enemyPoints.Count)
            {
                enemyIndexer = 0;
            }
            enemyIndexer++;
         GameObject findedenemy=Instantiate(enemy, point.position, point.rotation);
            findedenemy.GetComponent<EnemyActor>().GoToTargetPos(FindTargetDoor());

           }
    }
    private Vector3 FindTargetDoor()
    {
      
        GateActor gate=allGates[doorIndexer];
        doorIndexer++;
        if (doorIndexer >= allGates.Count) doorIndexer = 0;
        return gate.transform.position;

    }
  

    public void Shuffle<T>(List<T> list)
    {
         System.Random rng = new System.Random();
         int n = list.Count;
         while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    public void CreateBullet(Transform bulletPoint,EnemyActor enemy)
    {
        GameObject bullet = Instantiate(GameData.Instance.bullet, bulletPoint.transform.position, bulletPoint.transform.rotation);
        bullet.GetComponent<Bullet>().ThrowToEnemy(enemy);
    }
}
