    using UnityEngine;

    public class AudioManager : MonoBehaviour
    {
        // Make this a singleton so we can access it from anywhere
        public static AudioManager Instance;

        [Header("Audio Sources")]
        public AudioSource musicSource; // For background music
        public AudioSource sfxSource;   // For sound effects

        [Header("Audio Clips")]
        public AudioClip backgroundMusic;
        public AudioClip eatSound;
        public AudioClip shrinkSound;

        private void Awake()
        {
            // --- NEW, MORE ROBUST SINGLETON LOGIC ---

            // First, check if another instance already exists in the scene.
            if (Instance != null && Instance != this)
            {
                // If it does, and it's not me, then I am a duplicate. Destroy myself.
                Destroy(this.gameObject);
                return; // Stop running code in this script.
            }

            // If no other instance exists, then I will become the one and only Instance.
            Instance = this;

            // And we tell this object not to be destroyed when a new scene loads.
            DontDestroyOnLoad(this.gameObject);
        }

        // ... (the rest of your script stays exactly the same) ...
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

