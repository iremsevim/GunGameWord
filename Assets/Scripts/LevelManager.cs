using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class LevelManager : GameSingleActor<LevelManager>
{
  
    public List<Transform> enemyPoints;
    public List<GateActor> allGates;
    private int doorIndexer = 0;
    public float enemycreaterTimer = 1.5f;

    public override void ActorStart()
    {
     
    
       StartCoroutine(CreateEnemy());
       
      

    }
    
    public IEnumerator CreateEnemy()
    {
         int enemyIndexer = 0;
         Shuffle(enemyPoints);
         Shuffle(allGates);

        GameObject enemy= GameData.Instance.enemy;


        int count = 5 * (Coskunerov.Managers.GameManager.Instance.runtime.currentLevelIndex + 1);
        if (EnemyActor.SpecialWordDisplay)
            if (count<EnemyActor.SpecialWord.Length)
                count = EnemyActor.SpecialWord.Length;
        for (int i = 0; i <count; i++)
        {
            if (UIActor.Instance.finishHealth) yield break;
            Transform point = enemyPoints[enemyIndexer];
            enemyIndexer++;
            if (enemyIndexer>=enemyPoints.Count)
            {
                enemyIndexer = 0;
            }
            
           
            GameObject findedenemy=Instantiate(enemy, point.position, point.rotation);
            EnemyActor enemyy=findedenemy.GetComponent<EnemyActor>();
            enemyy.transform.SetParent(CustomLevelActor.Instance.transform);

            if (i%2== 0)
            {
                enemyy.ishavevowel = true;
            }
            enemyy.FindLetter();
            enemyy.anim.speed = Random.Range(0.75f, 1f);
            enemyy.GoToTargetPos(FindTargetDoor());
            yield return new WaitForSeconds(Random.Range(0.5f, 1.25f));
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

