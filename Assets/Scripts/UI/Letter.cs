using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class Letter : MonoBehaviour
{
    public string holdingLetter;
    private Button selfButton;
    public static System.Action<string> onDownLetterButton;
    public static bool letterLocked;
    
    private void Awake()
    {
        holdingLetter = transform.GetChild(3).GetComponent<TextMeshProUGUI>().text.ToUpper();
        selfButton = GetComponent<Button>();
    }
    private void Start()
    {
        selfButton.onClick.AddListener(() => PressKey());
    }
    public void PressKey()
    {
        if (letterLocked) return;
        if(PlayerActor.Instance.isGameWriteState)
        {
            if(PlayerActor.Instance.ownedWords.Any(x=>x.ToString()==holdingLetter))
            {
                UIActor.Instance.typedletters.text += holdingLetter;
            }
          
        }
        onDownLetterButton?.Invoke(holdingLetter);
   

    }
    
   
  
}
