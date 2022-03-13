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
    private TextMeshProUGUI textMeshProUGUI;
    private Image selfImage;

    private void Awake()
    {
        textMeshProUGUI = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        holdingLetter = textMeshProUGUI.text.ToUpper();
        selfButton = GetComponent<Button>();
        selfImage = GetComponent<Image>();
    }
    private void Start()
    {
        selfButton.onClick.AddListener(() => PressKey());
    }
    public void PressKey()
    {
        if (letterLocked) return;

        if (PlayerActor.Instance.isGameWriteState)
        {
            if (PlayerActor.Instance.ownedWords.Any(x => x.ToString() == holdingLetter))
            {
                UIActor.Instance.typedletters.text += holdingLetter;
                MakeWordPanel.Instance.writedLetters.Add(holdingLetter);
            }
        }
        onDownLetterButton?.Invoke(holdingLetter);


    }

    public void DisableEnable(bool status)
    {
        selfImage.raycastTarget = status;
        textMeshProUGUI.gameObject.SetActive(status);
    }
    
   
  
}
