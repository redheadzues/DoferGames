using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBalance : MonoBehaviour
{
    [SerializeField] private Image _balanceImage;
    [SerializeField] private TMP_Text _balanceText;
    [SerializeField] private PlayerWallet _wallet;

    private Vector3 _basePosition;

    private void OnEnable() => 
        _wallet.BalanceChanged += OnBalanceChanged;

    private void Start() => 
        _basePosition = transform.position;

    private void OnDisable() => 
        _wallet.BalanceChanged += OnBalanceChanged;

    private void OnBalanceChanged(int count)
    {
        _balanceText.text = count.ToString();
        _balanceImage.transform.DOShakePosition(1, 5).OnComplete(ReturnOnBasePosition);
    }

    private void ReturnOnBasePosition()
    {
        _balanceImage.transform.DOMove(_basePosition, 1);
    }
}
