using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
using DG.Tweening;

public class Keys : GameSingleActor<Keys>
{
    public Transform keyPoint;
    public Transform rotatableKey;
    public void ZoomKeys()
    {
        
        rotatableKey.DOLocalRotate(rotatableKey.transform.localEulerAngles+Vector3.up*480, 2f,RotateMode.FastBeyond360).OnComplete(()=> 
        {
            PlayerActor.Instance.FinishGame();
        });
       
        
    }
}
