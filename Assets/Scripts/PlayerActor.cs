using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;

public class PlayerActor : GameSingleActor<PlayerActor>
{
    public Animator anim;
    public List<LetterType> ownedWords;
    public Transform bulletPoint;
    public ParticleSystem bulletHit;
    public List<EnemyActor> enemieshit;
    public bool isGameWriteState;
    public override void ActorAwake()
    {
        Letter.onDownLetterButton = (string letter) =>
        {
            ownedWords.Add(GameData.Instance.allLetters.Find(X => X.letterType.ToString() == letter).letterType);
            LetterTypeController(letter);

        };
    }
    public void LetterTypeController(string enteredLetter)
    {
        if (isGameWriteState) return;

        EnemyActor findedletter = EnemyActor.allenemies.Find(x => x.letterType.ToString() == enteredLetter && !x.isDead);
        if (findedletter)
        {
             StartCoroutine(TrueCompare(findedletter));
            enemieshit.Add(findedletter);
        }
        else
        {
            Debug.Log("yanl�� e�le�me");
        }
    }
    public IEnumerator TrueCompare(EnemyActor enemy)
    {
       
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.01f);
        LevelManager.Instance.CreateBullet(bulletPoint, enemy);
        bulletHit.Play();
        Vector3 pos = transform.position - enemy.transform.position;
        float rot_y = Mathf.Atan2(pos.x, pos.z) * Mathf.Rad2Deg-180;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rot_y, transform.localEulerAngles.z);
      

    }
    public void FinishGame()
    {
        isGameWriteState = true;
        MakeWordPanel.Instance.ShowLetterPanel(enemieshit);
      
    }
}
   