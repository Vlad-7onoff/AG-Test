using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class FinishPanel : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private float _changeDuration;

    private CanvasGroup _canvasGroup;

    private void Awake() {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable() {
        _finish.Finished += OnFinished;
    }

    private void OnDisable() {
        _finish.Finished -= OnFinished;
    }

    private void OnFinished() {
        StartCoroutine(Show());
    }

    private IEnumerator Show() {
        yield return ChangeAlphaValue(1);
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = true;
    }

    private IEnumerator ChangeAlphaValue(float targetValue) {
        float elapsed = 0;
        float startValue = _canvasGroup.alpha;

        while (elapsed < _changeDuration) {
            elapsed += Time.deltaTime;
            _canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, elapsed / _changeDuration);
            yield return null;
        }
    }
}
