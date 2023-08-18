using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public int spectrumSize = 256; // 谱的大小，通常是2的幂次方

    private float[] spectrumData;

    private void Start()
    {
        spectrumData = new float[spectrumSize];
    }

    private void Update()
    {
        // 获取音频谱数据
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // 在这里可以使用spectrumData进行音频可视化或其他操作
    }
}
