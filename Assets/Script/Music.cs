using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip musicClip; // 音频剪辑
    public float beatTolerance = 0.1f; // 节奏点宽容范围，根据实际情况调整
    public ParticleSystem perfectParticleEffect; // 完美触发粒子效果
    public ParticleSystem normalParticleEffect; // 一般触发粒子效果

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
        InvokeRepeating("CheckRhythm", 0.1f, 0.1f); // 每隔0.1秒检查一次节奏
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

        // 在这里实现节奏检测的算法，获取音频频谱数据并找到节奏点

        // 假设检测到节奏点，并保存到变量 isBeat 上
        bool isBeat = false; // 替换成你的节奏检测结果

        if (isBeat)
        {
            // 完美触发效果
            if (Mathf.Abs(currentTime % 1.0f - 0.5f) < beatTolerance)
            {
                PlayPerfectEffect();
            }
            // 一般触发效果
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
        // 在这里实现完美触发的其他效果，比如改变角色状态等
    }

    private void PlayNormalEffect()
    {
        if (normalParticleEffect != null)
        {
            normalParticleEffect.Play();
        }
        // 在这里实现一般触发的其他效果，比如改变角色状态等
    }
}
