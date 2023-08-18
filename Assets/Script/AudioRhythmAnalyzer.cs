using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRhythmAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public int spectrumSize = 256;
    public float threshold = 0.5f; // 阈值，用于触发效果
    public GameObject effectObject; // 要触发的效果物体

    private float[] spectrumData;

    private void Start()
    {
        spectrumData = new float[spectrumSize];
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // 计算能量
        float energy = 0f;
        for (int i = 0; i < spectrumSize; i++)
        {
            energy += spectrumData[i];
        }

        // 如果能量超过阈值，则触发效果
        if (energy > threshold)
        {
            TriggerEffect();
        }
    }

    private void TriggerEffect()
    {
        // 在这里可以实现触发特定效果的逻辑
        if (effectObject != null)
        {
            effectObject.SetActive(true);
            Debug.Log("碰");
        }
    }
}
