using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public string holdingLetter;
    private Button selfButton;
    public static System.Action<string> onDownLetterButton;
    private void Awake()
    {
        holdingLetter = transform.GetChild(0).GetComponent<Text>().text;
        selfButton = GetComponent<Button>();
    }
    private void Start()
    {
        selfButton.onClick.AddListener(() => PressKey());
    }
    public void PressKey()
    {
        UIActor.Instance.typedletters.text += holdingLetter;
        onDownLetterButton?.Invoke(holdingLetter);
   

    }
   
  
}
