using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClip; // ��Ƶ����
    public float beatTolerance = 0.1f; // �������ݷ�Χ������ʵ���������
    public ParticleSystem perfectParticleEffect; // ������������Ч��
    public ParticleSystem normalParticleEffect; // һ�㴥������Ч��

    private AudioSource audioSource;
    private bool isPlaying = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (musicClip != null)
        {
            audioSource.clip = musicClip;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isPlaying)
            {
                StartMusic();
            }
            else
            {
                StopMusic();
            }
        }
    }

    private void StartMusic()
    {
        isPlaying = true;
        audioSource.Play();
        InvokeRepeating("CheckRhythm", 0.1f, 0.1f); // ÿ��0.1����һ�ν���
    }

    private void StopMusic()
    {
        isPlaying = false;
        audioSource.Stop();
        CancelInvoke("CheckRhythm");
    }

    private void CheckRhythm()
    {
        float currentTime = audioSource.time;

        // ������ʵ�ֽ�������㷨����ȡ��ƵƵ�����ݲ��ҵ������

        // �����⵽����㣬�����浽���� isBeat ��
        bool isBeat = false; // �滻����Ľ�������

        if (isBeat)
        {
            // ��������Ч��
            if (Mathf.Abs(currentTime % 1.0f - 0.5f) < beatTolerance)
            {
                PlayPerfectEffect();
            }
            // һ�㴥��Ч��
            else
            {
                PlayNormalEffect();
            }
        }
    }

    private void PlayPerfectEffect()
    {
        if (perfectParticleEffect != null)
        {
            perfectParticleEffect.Play();
        }
        // ������ʵ����������������Ч��������ı��ɫ״̬��
    }

    private void PlayNormalEffect()
    {
        if (normalParticleEffect != null)
        {
            normalParticleEffect.Play();
        }
        // ������ʵ��һ�㴥��������Ч��������ı��ɫ״̬��
    }
}
