using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActor : MonoBehaviour, ITriggerListener
{
    public void OnTouched(MonoBehaviour touched)
    {
       if(touched is EnemyActor enemy)
        {
         
            enemy.OnTouchedGate(this);
            StartCoroutine(Wait());
          
        }
       IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.1f);
            if (EnemyActor.allenemies.Count <= 0)
            {
                PlayerActor.Instance.FinishGame();
            }
        }
    }
}
