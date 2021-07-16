using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audio;
    private Coroutine _processingFadeAudio;
    private bool _isPlayingAlarm = false;

    private float _timeElapsed = 0;
    private float _minVolume = 0;
    private float _maxVolume = 1;


    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlayingAlarm = true;
            _processingFadeAudio = StartCoroutine(FadeAudio());
        }
        else
        {
            if (_processingFadeAudio != null)
            {
                StopCoroutine(_processingFadeAudio);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlayingAlarm = false;
            _processingFadeAudio = StartCoroutine(FadeAudio());
        }
        else
        {
            if (_processingFadeAudio != null)
            {
                StopCoroutine(_processingFadeAudio);
            }
        }
    }

    public void ChangeDirectionVolume(float startVolume, float endVolume)
    {
        _audio.volume = Mathf.Lerp(startVolume, endVolume, _timeElapsed / _duration);
        _timeElapsed += Time.deltaTime;
    }

    private IEnumerator FadeAudio()
    {

        if (_isPlayingAlarm)
        {
            _audio.Play();
            while (_timeElapsed < _duration)
            {
                ChangeDirectionVolume(_minVolume, _maxVolume);
                yield return null;
            }
            _timeElapsed = 0;
        }
        else
        {
            while (_timeElapsed < _duration)
            {
                ChangeDirectionVolume(_maxVolume, _minVolume);
                yield return null;
            }
            _timeElapsed = 0;
            _audio.Stop();
        }
    }
}


