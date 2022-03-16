using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
using Coskunerov.Managers;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;

public class MakeWordPanel : GameSingleActor<MakeWordPanel>
{
    public Transform letterCarrier;
    public GameObject mainLetterPanel;
    public GameObject applyButton;
    public Image typedlettersCarrier;
    public List<string> createdletters;
    public List<string> writedLetters;


    private void CreateLetter(List<EnemyActor> aliveCounters)
    {
        foreach (Transform item in letterCarrier)
        {
            Destroy(item.gameObject);
        }
       
        foreach (var item in aliveCounters)
        {
           GameObject createdletter= Instantiate(GameData.Instance.UIletter, Vector3.zero, Quaternion.identity, letterCarrier);
          Sprite lettericon= GameData.Instance.allLetters.Find(x => x.letterType == item.letterType).letter;
            createdletter.GetComponent<UILetter>().letter.sprite= lettericon;
            createdletters.Add((GameData.Instance.allLetters.Find(x => x.letter == createdletter.GetComponent<UILetter>().letter.sprite).letterType.ToString()));
        }
    }
    public void ShowLetterPanel(List<EnemyActor> aliveCounters)
    {
        
        if(UIActor.Instance.finishHealth)
        {
            Debug.Log("ÝREM");
            GameManager.Instance.FinishLevel(false);
            return;
        }
        mainLetterPanel.SetActive(true);
        CreateLetter(aliveCounters);

    }
   
public void CheckAnswer()
    {
        if (GameData.CheckWord(UIActor.Instance.typedletters.text))
        {
           
                Debug.Log("win");
                GameManager.Instance.FinishLevel(true);
        }
        
        else
        {
            
            Debug.Log("losee");
            applyButton.SetActive(false);
            Letter.letterLocked = true;
            var Sequence = DOTween.Sequence().Append(typedlettersCarrier.DOColor(Color.red, 0.5f)).
                Append(typedlettersCarrier.transform.DOShakePosition(0.5f, 8f)).OnComplete(() =>
                {
                    typedlettersCarrier.DOColor(Color.white, 0.5f);
                    Letter.letterLocked = false;
                    applyButton.SetActive(true);
                });

        }
    }
}
