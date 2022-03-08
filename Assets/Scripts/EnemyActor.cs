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

    private void Awake()
    {
        anim = GetComponent<Animator>();
        allenemies.Add(this);

    }
    private void OnDestroy()
    {
        allenemies.Remove(this);
    }
    public void GoToTargetPos(Vector3 pos)
    {
        agent.SetDestination(pos);
       
    }
}
