using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GearEntry gearEntry;
    [SerializeField]
    private ScoreEntry scoreEntry;
    [SerializeField]
    private Transform trashContentList;
    [SerializeField]
    private GameObject trashEntryPrefab;
    [SerializeField]
    private ScrollRect scrollRect;

    private List<GameObject> trashEntries = new List<GameObject>();

    public void ResetEntries()
    {
        StopAllCoroutines();
        gearEntry.ResetEntry();
        scoreEntry.ResetEntry();
        foreach(var obj in trashEntries)
            Destroy(obj);
        trashEntries.Clear();
    }

    public IEnumerator COAddTrashEntry(string name, int quantity, int score, int gear)
    {
        GameObject entryObj = Instantiate(trashEntryPrefab, trashContentList);
        trashEntries.Add(entryObj);
        TrashEntry entry = entryObj.GetComponent<TrashEntry>();
        yield return entry.COSetEntry(name, quantity, score, gear);
    }

    public void SetGearEntry(int gear)
    {
        gearEntry.SetEntry(gear);
    }

    public IEnumerator COSetScoreEntry(int total, int trash, int enemy, int distance)
    {
        yield return scoreEntry.COSetEntry(total, trash, enemy, distance);
        scrollRect.verticalNormalizedPosition += 0.1f;
    }
}
