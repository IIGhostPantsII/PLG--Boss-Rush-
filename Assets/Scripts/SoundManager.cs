using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource _source;
    public AudioClip[] _clips;
    public AudioClip[] _music;

    public static SoundManager _instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
    
    public void PlayMusic(int musicIndex)
    {
        _source.Stop();
        _source.clip = _music[musicIndex];
        _source.loop = true;
        _source.time = 0; // set the time of the audio source to the start time
        _source.Play();
        LoopSong loopScript = _source.GetComponent<LoopSong>();
        if (loopScript != null)
        {
            loopScript.LoadStartEndTime(_source.clip.name);
        }
    }
}
