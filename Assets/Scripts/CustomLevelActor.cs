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

    public override void SetupLevel()
    {
        EnemyActor.SpecialWordDisplay = Coskunerov.Managers.GameManager.Instance.runtime.currentLevelIndex == 2;
    }

    private void CreatePlayer()
    {
        Instantiate(GameData.Instance.player, playerPoint.position, playerPoint.rotation).transform.SetParent(transform);
    }

    [ContextMenu("Clear")]
    void DoSomething()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Cleared");
    }
}
