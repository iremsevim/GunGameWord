using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
using System.IO;
using System.Linq;

public class GameData : GameSingleActor<GameData>
{
    public GameObject player;
    public GameObject enemy;
    public GameObject bullet;
    public List<LetterProfile> allLetters;
    [Header("UI")]
    public GameObject UIletter;
     static  HashSet<string> allWords = new HashSet<string>();


    public override void ActorAwake()
    {
        ReadWords();
    }
   
    private void ReadWords() 
    {
        TextAsset mytxtData = (TextAsset)Resources.Load("words");
        string txt = mytxtData.text;
        var parts= txt.Split('\n');
        foreach (var item in parts)
        {
            allWords.Add(item.ToLower());
        }
    }

    public static bool CheckWord(string word)
    {
      return  allWords.Contains(word.ToLower());
    }
       

    [System.Serializable]
    public class LetterProfile
    {
        public LetterType letterType;
        public Sprite letter;
    }
}
public enum LetterType
{
    A,
    B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, R, S, T, U, V, Y, Z, W,Q,X
}
