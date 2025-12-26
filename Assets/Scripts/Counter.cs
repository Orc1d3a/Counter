using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Counter : MonoBehaviour
{
    private int _currentValue = 0;
    private int _additionalNumber = 1;
    private float _period = 0.5f;

    [SerializeField] TextMeshProUGUI _text;

    private bool _isEnable;
    private bool _isCount = true;

    private void Start()
    {
        StartCoroutine(Count());
    }

    private void Update()
    {
        int mouseButtonLeft = 0;

        if (Input.GetMouseButton(mouseButtonLeft))
            _isCount = !(_isCount);
    }

    private IEnumerator Count()
    {
        while (_isEnable)
        {
            yield return new WaitUntil(() => (_isCount == true));
            yield return new WaitForSecondsRealtime(_period);

            _currentValue += _additionalNumber;
            _text.text = _currentValue.ToString();
        }
    }

    private void OnEnable()
    {
        _isEnable = true;
    }

    private void OnDisable()
    {
        _isEnable = false;
    }
}
