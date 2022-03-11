using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
using DG.Tweening;

public class Keys : GameSingleActor<Keys>
{
    public Transform keyPoint;
    public Transform rotatableKey;
    public IEnumerator ZoomKeys()
    {
        Debug.Log("ÝREMMMMMM");
        rotatableKey.DOLocalRotate(rotatableKey.transform.localEulerAngles+Vector3.up*480, 4f,RotateMode.FastBeyond360);
        yield return new WaitForSeconds(4f);
        PlayerActor.Instance.FinishGame();
    }
}
