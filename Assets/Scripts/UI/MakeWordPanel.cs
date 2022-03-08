using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
using Coskunerov.Managers;

public class MakeWordPanel : GameSingleActor<MakeWordPanel>
{
    public Transform letterCarrier;
    public GameObject mainLetterPanel;

     private void CreateLetter(List<EnemyActor> aliveCounters)
    {
        foreach (Transform item in letterCarrier)
        {
            Destroy(item.gameObject);
        }
        if (aliveCounters.Count <= 0)
        {
            GameManager.Instance.FinishLevel(false);
        }
        foreach (var item in aliveCounters)
        {
           GameObject createdletter= Instantiate(GameData.Instance.UIletter, Vector3.zero, Quaternion.identity, letterCarrier);
          Sprite lettericon= GameData.Instance.allLetters.Find(x => x.letterType == item.letterType).letter;
            createdletter.GetComponent<UILetter>().letter.sprite= lettericon;
        }
    }
    public void ShowLetterPanel(List<EnemyActor> aliveCounters)
    {
        mainLetterPanel.SetActive(true);
        CreateLetter(aliveCounters);
       
    }
}
