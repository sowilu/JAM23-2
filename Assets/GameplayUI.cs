using System;
using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : UnitySingleton<GameplayUI>
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public Image cooldownImage;
    public TMP_Text announceText;
    public CanvasGroup announceTextCanvasGroup;

    public LeaderboardUI leaderboardUI;
    
    [Header("Announcer")]
    public float duration = 5f;
    public float fadeDuration = 1f;
    public Wand wand;


    private void Start()
    {
        Health.onAnyDamage.AddListener((dmg) =>
        {
            scoreText.text = GameManager.score.ToString();
            highScoreText.text = "best: " +  GameManager.highScore.ToString();
        });
        
        announceTextCanvasGroup.alpha = 0;
        
        
    }

    private void LateUpdate()
    {
                    
        cooldownImage.fillAmount = 1 - wand.cooldownLeft / wand.coolDown;
    }

    public void Announce(string text)
    {
        StartCoroutine(AnnounceRoutine(text));
    }


    IEnumerator AnnounceRoutine(string text)
    {
        // fade in
        announceText.text = text;
        for( float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            announceTextCanvasGroup.alpha = t / fadeDuration;
            yield return null;
        }
        
        yield return new WaitForSeconds(duration);
        
        // fade out
        for( float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            announceTextCanvasGroup.alpha = 1f - t / fadeDuration;
            yield return null;
        }
        announceTextCanvasGroup.alpha = 0f;
        
        announceText.text = "";
    }
    
    
}
