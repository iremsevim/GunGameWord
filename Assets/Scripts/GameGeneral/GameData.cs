using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class GameData : GameSingleActor<GameData>
{
    public GameObject player;
    public List<LetterProfile> allLetters;
      
    [System.Serializable]
    public class LetterProfile
    {

        public Sprite letter;
    }
}
