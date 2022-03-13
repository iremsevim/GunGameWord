using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Coskunerov.Actors;
using UnityEngine.UI;
using Coskunerov.EventBehaviour;
using Coskunerov.EventBehaviour.Attributes;
//using ElephantSDK;
using System.Linq;


public class UIActor : GameSingleActor<UIActor>
{
    public RectTransform letterpanel;
    public RectTransform upPos;
    public RectTransform downPos;

    public Text typedletters;
    private Color panelColor;
    [Header("UI Panels")]
    public GameObject winPanel;
    public GameObject failPanel;
    public List<Image> healths;
    public int heathCounter;

    public override void ActorAwake()
    {
        heathCounter = healths.Count;
      //  panelColor = letterpanel.GetComponent<Image>().color;
    }

    public void ShowHideLetterPanel(bool status)
    {
        if (status)
        {
            letterpanel.DOMove(upPos.position, 0.75f);
        }
        else
        {
            letterpanel.DOMove(downPos.position, 0.75f);
        }
    }
    public void DecreaseHealth()
    {
        
        if (heathCounter <= 0) return;
        heathCounter--;
        healths[heathCounter].transform.DOScale(healths[heathCounter].transform.localScale/2f, 0.25f).OnComplete(() => 
       {
           healths[heathCounter].gameObject.SetActive(false);
           healths[heathCounter].transform.DOScale(healths[heathCounter].transform.localScale * 2f, 0.25f);
        

       });
     
        
    }
        
    public IEnumerator ClearTypedLetter(bool status)
    {
        if(status)
        {
            letterpanel.GetComponent<Image>().color = Color.green;
            typedletters.text = string.Empty;
            yield return new WaitForSeconds(2F);
            letterpanel.GetComponent<Image>().color = panelColor;
        }
        else
        {
           
            typedletters.text = string.Empty;
            letterpanel.GetComponent<Image>().color = Color.red;
            letterpanel.DOShakePosition(0.5f, 5, 45).OnComplete(() => 
            {
                letterpanel.GetComponent<Image>().color = panelColor;
            });
          //  yield return new WaitForSeconds(1.5f);
            

        }
      


    }
    public void DeleteText(List<string> currentWords)
    {
        currentWords.RemoveAt(currentWords.Count - 1);
        typedletters.text = typedletters.text.Substring(0, typedletters.text.Length - 1);


    }


    public void NextLevel()
    {
        Coskunerov.Managers.GameManager.Instance.NextLevel();

       


    }

    [GE(BaseGameEvents.WinGame)]
    public void WinGame()
    {
        winPanel.SetActive(true);
        failPanel.SetActive(false);
       // Elephant.LevelCompleted(Coskunerov.Managers.GameManager.Instance.runtime.currentLevelIndex);
    }
    [GE(BaseGameEvents.LoseGame)]
    public void FailGame()
    {
        winPanel.SetActive(false);
        failPanel.SetActive(true);
     
        //Elephant.LevelFailed(Coskunerov.Managers.GameManager.Instance.runtime.currentLevelIndex);
    }
    [GE(BaseGameEvents.FinishGame)]
    public void FinishGame()
    {
       
        ShowHideLetterPanel(false);
      
    }
    public void Retry()
    {
     
        Coskunerov.Managers.GameManager.Instance.RestartLevel();
        PlayerActor.Instance.ownedWords.Clear();
        //PlayerController.Instance.LevelLoaded();
       
    }
    [GE(BaseGameEvents.LevelLoaded)]
    public void LoadLevel()
    {
        winPanel.SetActive(false);
        failPanel.SetActive(false);
        ShowHideLetterPanel(true);

        PlayerActor.Instance.LevelLoaded();
        typedletters.text = string.Empty;
        PlayerActor.Instance.ownedWords.Clear();

        FindObjectsOfType<Letter>().ToList().ForEach(x => x.DisableEnable(true));


    }
    public void Delete()
    {
        if (typedletters.text.Length <= 0) return;
       typedletters.text = typedletters.text.Substring(0,typedletters.text.Length - 1);
    }
}
