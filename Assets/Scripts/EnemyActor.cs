using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Coskunerov.Resources;
using Coskunerov.Utilities;
public class EnemyActor : MonoBehaviour
{
    public static List<EnemyActor> allenemies = new List<EnemyActor>();
    public NavMeshAgent agent;
    public Animator anim;
    public Image ownedLetter;
    public LetterType letterType;
    public bool isDead = false;
    public ParticleSystem smoke;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        allenemies.Add(this);
        agent.speed = Random.Range(2f,2.5f);
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
    public void Dead(EnemyActor shuttedenemy)
    {
        isDead = true;
        agent.isStopped = true;
        anim.SetTrigger("fall");
        smoke.Play();


    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ITriggerListener trigger))
        {
            trigger.OnTouched(this);
        }
    }
    public void OnTouchedGate(GateActor gate)
    {
        ParticleFXDisplayer smoke = new ParticleFXDisplayer() { destroyTime = 4f, particleID = "smoke", position = transform.position };
        smoke.Display();
       Destroy(gameObject);
       
    }
}
