    using UnityEngine;

    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [Header("Audio Sources")]
        public AudioSource musicSource;
        public AudioSource sfxSource;

        [Header("Audio Clips")]
        public AudioClip backgroundMusic;
        public AudioClip eatSound;
        public AudioClip shrinkSound;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(this.gameObject);
        }

        public void PlayMusic()
        {
            if (musicSource != null && backgroundMusic != null)
            {
                musicSource.clip = backgroundMusic;
                musicSource.loop = true;
                musicSource.Play();
            }
        }

        public void PlayEatSound()
        {
            sfxSource.PlayOneShot(eatSound);
        }

        public void PlayShrinkSound()
        {
            sfxSource.PlayOneShot(shrinkSound);
        }
    }

