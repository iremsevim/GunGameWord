using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using MoreMountains.NiceVibrations;

public class Bullet : MonoBehaviour
{
   
    public void ThrowToEnemy(EnemyActor enemy)
    {
        if (enemy==null || enemy.isShutted)return;
        enemy.isShutted = true;
        transform.DOMove(enemy.transform.position, Random.Range(0.1f, 0.2f)).OnComplete(() =>
        {
             
            enemy.Dead(enemy);
            MMVibrationManager.Haptic(HapticTypes.RigidImpact);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(Wait());

        });
        IEnumerator Wait()
        {
            enemy.smoke.transform.SetParent(CustomLevelActor.Instance.transform);
            Destroy(enemy.smoke.gameObject, 3F);
            enemy.smoke.Play();
            yield return new WaitForSeconds(0.3f);
            if (enemy == null) yield break;
            Destroy(enemy.gameObject);
            yield return new WaitForSeconds(0.1f);
          
            if (EnemyActor.allenemies.Count <= 0)
            {
               
                SwitchCamera.Instance.Switch(SwitchCamera.CameraType.keysCamera);
             Keys.Instance.ZoomKeys();
            }
            Destroy(gameObject);




        }
    }
}
