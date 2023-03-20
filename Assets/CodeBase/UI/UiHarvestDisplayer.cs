using Assets.CodeBase.Character;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.CodeBase.UI
{
    public class UiHarvestDisplayer : MonoBehaviour
    {
        [SerializeField] private RewardCollector _rewardCollector;
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Slider _progressSlider;

        private Coroutine _sliderCoroutine;

        private void OnEnable() => 
            _rewardCollector.BrickCountChanged += OnBrickCollected;

        private void OnDisable() => 
            _rewardCollector.BrickCountChanged -= OnBrickCollected;

        private void OnBrickCollected(int currentCount, int maxCount)
        {
            float value = (float)currentCount / (float)maxCount;
            //StartFillSlider(currentCount, maxCount);
            _progressSlider.DOValue(value, 1);
            _countText.text = $"{currentCount}/{maxCount}";
        }

        private void StartFillSlider(int currentCount, int maxCount)
        {
            if (_sliderCoroutine != null)
                StopCoroutine(_sliderCoroutine);

            _sliderCoroutine = StartCoroutine(OnFillSlider(currentCount, maxCount));
        }

        private IEnumerator OnFillSlider(int currentCount, int maxCount)
        {
            float value = (float)currentCount / (float)maxCount;

            while(_progressSlider.value != value)
            {
                _progressSlider.value = Mathf.Lerp(_progressSlider.value, value, 0.01f);

                yield return null;
            }
        }
    }
}
