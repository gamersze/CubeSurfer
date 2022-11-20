using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelProgressUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI uiStartText;
    [SerializeField] private TextMeshProUGUI uiEndText;
    [SerializeField] private Image uiFillImage;

    [Header("Player & EndLine References")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform endLineTransform;

    private float fullDistance;

    private Vector3 endLinePosition;

    public void Start()
    {
        endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();

    }


    public void SetLevelTexts(int level)
    {
        uiStartText.text = level.ToString();
        uiEndText.text = (level + 1).ToString();

    }

    public float GetDistance()
    {
        return (endLinePosition - playerTransform.position).sqrMagnitude;
    }

    public void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }

    public void Update()
    {
        if (playerTransform.position.z <= endLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

            UpdateProgressFill(progressValue);
        }


    }

}
