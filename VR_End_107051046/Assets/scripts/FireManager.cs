
using UnityEngine;

public class FireManager : MonoBehaviour

{
    [Header("煙火音效")]
    public AudioClip soundIn;
    [Header("煙火特效")]
    public ParticleSystem firework;

    private AudioSource aud;
    private ParticleSystem particleObject;

    public bool fire;

    private void Awake()
    {
        // 音效來源 = 取得元件<音效來源>()
        aud = GetComponent<AudioSource>();
        particleObject = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bomb")
        {
            Explode();
            fire = true;
        }
    }

    private void Explode()
    {
        aud.PlayOneShot(soundIn, Random.Range(1f, 5f));
    }

     private void Update()
    {
        if (fire)
        {
            firework.Play();
        }

        else if (!fire)
        {
            firework.Stop();
        }
    }
}

