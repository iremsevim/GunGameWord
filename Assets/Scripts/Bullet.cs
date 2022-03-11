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
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Wait());

        });
        IEnumerator Wait()
        {
            enemy.smoke.transform.SetParent(CustomLevelActor.Instance.transform);
            Destroy(enemy.smoke.gameObject, 3F);
            enemy.smoke.Play();
            yield return new WaitForSeconds(0.3f);
            Destroy(enemy.gameObject);
            yield return new WaitForSeconds(0.1f);
          
            if (EnemyActor.allenemies.Count <= 0)
            {
               
                SwitchCamera.Instance.Switch(SwitchCamera.CameraType.keysCamera);
               Coskunerov.Managers.GameManager.Instance.StartCoroutine(Keys.Instance.ZoomKeys());

            }
            Destroy(gameObject);




        }
    }
}
