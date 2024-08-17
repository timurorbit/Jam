using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshProUgui;

    [SerializeField] private oscillator bee;
    private void Start()
    {
        _textMeshProUgui = GetComponent<TextMeshProUGUI>();
        bee = FindObjectOfType<oscillator>();
    }

    private void Update()
    {
        _textMeshProUgui.text = "Scores: " + bee.score;
    }
}
