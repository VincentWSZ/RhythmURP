using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrumAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public int spectrumSize = 256; // �׵Ĵ�С��ͨ����2���ݴη�

    private float[] spectrumData;

    private void Start()
    {
        spectrumData = new float[spectrumSize];
    }

    private void Update()
    {
        // ��ȡ��Ƶ������
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // ���������ʹ��spectrumData������Ƶ���ӻ�����������
    }
}
