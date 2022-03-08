using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyActor : MonoBehaviour
{
    public static List<EnemyActor> allenemies = new List<EnemyActor>();
    public NavMeshAgent agent;
    public Animator anim;
    public Image ownedLetter;
    public LetterType letterType;
    public bool isDead = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        allenemies.Add(this);
        FindLetter();

    }
    private void OnDestroy()
    {
        allenemies.Remove(this);
    }
    public void GoToTargetPos(Vector3 pos)
    {
        agent.SetDestination(pos);
       
    }
    public void FindLetter()
    {
        List<GameData.LetterProfile> alllletters=  GameData.Instance.allLetters;
        LevelManager.Instance.Shuffle(alllletters);
        int letterIndex= Random.Range(0, alllletters.Count);
        ownedLetter.sprite = alllletters[letterIndex].letter;
        letterType = alllletters[letterIndex].letterType;

    }
    public void Dead()
    {
        isDead = true;
        agent.isStopped = true;
        anim.SetTrigger("fall");
    }
}
