using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coskunerov.Actors;
public class CustomLevelActor : LevelActor
{

    public Transform playerPoint;
    public override void ActorAwake()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Instantiate(GameData.Instance.player, playerPoint.position, playerPoint.rotation).transform.SetParent(transform);
    }
}
