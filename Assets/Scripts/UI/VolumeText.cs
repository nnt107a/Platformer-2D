﻿using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro;
    private Text txt;
    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    private void Update()
    {
        UpdateVolume();
    }
    private void UpdateVolume()
    {
        txt.text = textIntro + (PlayerPrefs.GetFloat(volumeName) * 100).ToString();
    }
}