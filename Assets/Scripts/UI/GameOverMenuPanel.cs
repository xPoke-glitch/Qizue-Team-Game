using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xPoke.CustomLog;

public class GameOverMenuPanel : GameMenuPanel
{
    // Add recap menu reference here
    [Header("GameOver References")]
    [SerializeField]
    private RecapPanel recapPanel;

    public override void Open()
    {
        base.Open();

        // Load data on recap panel
        SetRecapPanel();
    }

    private void SetRecapPanel()
    {
        foreach (string name in TrashCollectedManager.Instance.TrashCountDictionary.Keys)
        {
            recapPanel.AddTrashEntry(name, TrashCollectedManager.Instance.TrashCountDictionary[name],
                (TrashCollectedManager.Instance.TrashCountDictionary[name] * TrashCollectedManager.Instance.TrashDictionary[name].ScorePoints),
                (TrashCollectedManager.Instance.TrashCountDictionary[name] * TrashCollectedManager.Instance.TrashDictionary[name].Gear));
        }

        recapPanel.SetScoreEntry(GameController.Instance.Score, 
            TrashCollectedManager.Instance.GetTotalScoreFromTrash(),
            EnemyKilledManager.Instance.TotalPoints, 
            (GameController.Instance.Score - TrashCollectedManager.Instance.GetTotalScoreFromTrash() - EnemyKilledManager.Instance.TotalPoints));
        
        recapPanel.SetGearEntry(TrashCollectedManager.Instance.GetTotalGearCount());
    }
}
