using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
   
    public void ThrowToEnemy(EnemyActor enemy)
    {
        transform.DOMove(enemy.transform.position, Random.Range(0.1f, 0.2f)).OnComplete(() =>
        {
            enemy.Dead();
            Destroy(gameObject);

        });
    }
}
