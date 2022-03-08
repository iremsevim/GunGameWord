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
          
            enemy.Dead(enemy);
            StartCoroutine(Wait());

        });
        IEnumerator Wait()
        {
            enemy.smoke.Play();
            yield return new WaitForSeconds(0.2f);
            Destroy(enemy.gameObject);
            yield return new WaitForSeconds(0.1f);
            if (EnemyActor.allenemies.Count <= 0)
            {
                PlayerActor.Instance.FinishGame();

            }
            Destroy(gameObject);




        }
    }
}
