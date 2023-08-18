using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRhythmAnalyzer : MonoBehaviour
{
    public AudioSource audioSource;
    public int spectrumSize = 256;
    public float threshold = 0.5f; // ��ֵ�����ڴ���Ч��
    public GameObject effectObject; // Ҫ������Ч������

    private float[] spectrumData;

    private void Start()
    {
        spectrumData = new float[spectrumSize];
    }

    private void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

        // ��������
        float energy = 0f;
        for (int i = 0; i < spectrumSize; i++)
        {
            energy += spectrumData[i];
        }

        // �������������ֵ���򴥷�Ч��
        if (energy > threshold)
        {
            TriggerEffect();
        }
    }

    private void TriggerEffect()
    {
        // ���������ʵ�ִ����ض�Ч�����߼�
        if (effectObject != null)
        {
            effectObject.SetActive(true);
            Debug.Log("��");
        }
    }
}
