using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioData
{
    public string name;
    public AudioClip audioClip;
}

public class AudioManager : MonoBehaviour {

    public AudioData[] music, sfx;

    public AudioSource audioSource;

    public bool playOnAwake = true;

    private Dictionary<string, AudioData> musicDict = new Dictionary<string, AudioData>();
    private Dictionary<string, AudioData> sfxDict = new Dictionary<string, AudioData>();

    void Start () {

        foreach (AudioData audio in music)
        {
            musicDict.Add(audio.name, audio);
        }

        foreach (AudioData audio in sfx)
        {
            sfxDict.Add(audio.name, audio);
        }

    }
	
	public void PlayMusic (string name)
    {
        audioSource.clip = musicDict[name].audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void PlayMusic(int index)
    {
        PlayMusic( music [index].name );
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlaySfx(string name)
    {
        GameObject go = new GameObject();
        AudioSource a = go.AddComponent<AudioSource>();
        Destroy(go, 5f);

        a.spatialBlend = 0;
        a.clip = sfxDict[name].audioClip;
        a.Play();
    }

    public void PlaySfx(int index)
    {
        PlaySfx(sfx[index].name);
    }

}
