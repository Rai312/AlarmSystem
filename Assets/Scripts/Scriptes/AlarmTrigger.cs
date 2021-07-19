using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _audio;
    private Coroutine _coroutine;
    private bool _isPlayingAlarm = false;
    private float _timeElapsed = 0;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlayingAlarm = true;
            _coroutine = StartCoroutine(FadeAudio());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isPlayingAlarm = false;
            _coroutine = StartCoroutine(FadeAudio());
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }

    private IEnumerator FadeAudio()
    {

        if (_isPlayingAlarm)
        {
            _audio.Play();
            while (_timeElapsed < _duration)
            {
                _audio.volume = Mathf.Lerp(0, 1, _timeElapsed / _duration);
                _timeElapsed += Time.deltaTime;
                yield return null;
            }
            _timeElapsed = 0;
        }
        else
        {
            while (_timeElapsed < _duration)
            {
                _audio.volume = Mathf.Lerp(1, 0, _timeElapsed / _duration);
                _timeElapsed += Time.deltaTime;
                yield return null;
            }
            _timeElapsed = 0;
            _audio.Stop();
        }
    }
}

