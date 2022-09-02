using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class AchievementPopUp : MonoBehaviour
{
    public bool IsPlaying { get; private set; }

    [Header("References")]
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float duration = 1.0f;

    public void Play(Achievement achievement, Action callback)
    {
        if (IsPlaying)
            return;
        descriptionText.text = achievement.Data.Description + " Unlocked <Tier " + achievement.Data.CurrentTier + ">";
        StartCoroutine(Play(callback));
    }

    private IEnumerator Play(Action callback)
    {
        IsPlaying = true;
        animator.SetTrigger("Open");
        yield return new WaitForSeconds(1.0f + duration);
        animator.SetTrigger("Close");
        yield return new WaitForSeconds(1.2f);
        IsPlaying = false;
        callback?.Invoke();
    }
}
