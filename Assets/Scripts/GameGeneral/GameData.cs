using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class GameData : GameSingleActor<GameData>
{
    public GameObject player;
    public GameObject enemy;
    public GameObject bullet;
    public List<LetterProfile> allLetters;
      
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
