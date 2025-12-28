using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int CurrentValue { get; private set; } = 0;

    private int _additionalNumber = 1;
    private float _period = 0.5f;

    [SerializeField] InputReader _inputReader;
    private Coroutine _coroutineCount;

    public event Action ValueChanged;

    private bool _isCount = false;

    private void OnEnable()
    {
        _inputReader.LeftButtonClicked += StartAndStopCoroutine;
    }

    private void OnDisable()
    {
        _inputReader.LeftButtonClicked -= StartAndStopCoroutine;
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

    private IEnumerator Count()
    {
        bool isCount = true;

        while (isCount)
        {
            yield return new WaitForSecondsRealtime(_period);

            CurrentValue += _additionalNumber;
            ValueChanged?.Invoke();
        }
    }
}
