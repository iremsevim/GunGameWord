using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Coskunerov.Resources;
using Coskunerov.Utilities;
using DG.Tweening;

public class EnemyActor : MonoBehaviour
{
    public static List<EnemyActor> allenemies = new List<EnemyActor>();
    public NavMeshAgent agent;
    public Animator anim;
    public Image ownedLetter;
    public LetterType letterType;
    public bool isDead = false;
    public ParticleSystem smoke;
    public bool ishavevowel;
    public Transform canvas;
    
   
    private void Awake()
    {
     
        anim = GetComponent<Animator>();
        allenemies.Add(this);
        agent.speed = Random.Range(2f,2.5f);
       

    }
    public void Update()
    {
        var fwd = Camera.main.transform.forward;
        fwd.y = 0.0F;
        ownedLetter.transform.rotation = Quaternion.LookRotation(fwd);
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
        List<GameData.LetterProfile> vowels = alllletters.FindAll(x=>x.isvowel== ishavevowel);
         int index= Random.Range(0, vowels.Count);
        ownedLetter.sprite = vowels[index].letter;
       letterType = vowels[index].letterType;
        
       
        
        
    }
    public void Dead(EnemyActor shuttedenemy)
    {
        isDead = true;
        agent.isStopped = true;
        anim.SetTrigger("fall");
        smoke.Play();
        canvas.SetParent(null);
        canvas.transform.position = transform.position + Vector3.up * 3f;
        canvas.transform.DOScale(canvas.transform.localScale / 2, 0.75f);
        var sequence = DOTween.Sequence().
            Append(canvas.transform.DOMove(Keys.Instance.keyPoint.position, 0.75f)).
            Append(Keys.Instance.transform.DOPunchScale(Keys.Instance.transform.localScale * 1.45f, 0.15f)).
            Append(Keys.Instance.transform.DOPunchScale(Keys.Instance.transform.localScale / 1.45f, 0.15f)).
            OnComplete(() =>
            {
               
                Destroy(canvas.gameObject);
            });

       
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
