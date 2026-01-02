using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    public int CurrentValue { get; private set; } = 0;
    public event Action ValueChanged;

    private int _additionalNumber = 1;
    private float _period = 0.5f;

    private Coroutine _coroutineCount;
    private bool _isCount = false;

    private IEnumerator Count()
    {
        bool isCount = true;
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(_period);

        while (isCount)
        {
            yield return wait;

            CurrentValue += _additionalNumber;
            ValueChanged?.Invoke();
        }
    }

    private void StartAndStopCoroutine()
    {
        if (_isCount == true)
        {
            _isCount = false;
            _coroutineCount = StartCoroutine(Count());
        }
        else
        {
            _isCount = true;

            if (_coroutineCount != null)
                StopCoroutine(_coroutineCount);
        }
    }

    private void OnEnable()
    {
        _inputReader.LeftButtonClicked += StartAndStopCoroutine;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonClicked -= StartAndStopCoroutine;
    }
}
