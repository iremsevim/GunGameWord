using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;

public class PlayerActor : GameSingleActor<PlayerActor>
{
    public Animator anim;
    public List<LetterType> ownedWords;
    public Transform bulletPoint;

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
       EnemyActor findedletter= EnemyActor.allenemies.Find(x => x.letterType.ToString() == enteredLetter && !x.isDead);
        if(findedletter)
        {
            TrueCompare(findedletter);
        }
        else
        {
            Debug.Log("yanlýþ eþleþme");
        }
    }
    public void TrueCompare(EnemyActor enemy)
    {
        LevelManager.Instance.CreateBullet(bulletPoint,enemy);
    }
}
   