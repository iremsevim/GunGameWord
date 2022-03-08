using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;

public class PlayerActor : GameSingleActor<PlayerActor>
{
    public Animator anim;
    public List<LetterType> ownedWords;

    public override void ActorAwake()
    {
        Letter.onDownLetterButton = (string letter) =>
        {
            ownedWords.Add(GameData.Instance.allLetters.Find(X => X.letterType.ToString() == letter).letterType);


        };
    }
}
   