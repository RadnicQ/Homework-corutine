using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _updateTime = 0.5f;
    [SerializeField] private float _stepValue = 1f;
    [SerializeField] private PlayerEnter _playerEnter;

    private float _realtimeValue = 0f;
    private bool _isCorutinePlay = false;
    private Coroutine _coroutine;

    public event Action<float> Counting;

    private void OnEnable() =>
        _playerEnter.Enter += SwitchTimer;

    private void OnDisable() =>
        _playerEnter.Enter -= SwitchTimer;

    private void SwitchTimer()
    {
        if (_isCorutinePlay == false)
        {
            _isCorutinePlay = true;
            OnTimer();
            return;
        }

        if (_isCorutinePlay == true)
        {
            _isCorutinePlay = false;
            OffTimer();
        }
    }

    private void OnTimer() =>
        _coroutine = StartCoroutine(IncreaseInNumber());

    private void OffTimer()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator IncreaseInNumber()
    {
        WaitForSeconds updateTime = new WaitForSeconds(_updateTime);

        while (_isCorutinePlay)
        {
            yield return updateTime;

            _realtimeValue += _stepValue;
            Counting?.Invoke(_realtimeValue);
        }
    }
}
