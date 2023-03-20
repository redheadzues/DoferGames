using UnityEngine;

public class PlayerRewarder : MonoBehaviour
{
    [SerializeField] private Coin _coinsPrefab;
    [SerializeField] private RectTransform _coinsPoint;
    [SerializeField] private PlayerWallet _playerWallet;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void Reward(int money, Vector3 point)
    {
        var canvasPoint = _camera.WorldToScreenPoint(point);

        Coin coin = Instantiate(_coinsPrefab, transform);
        coin.transform.position = canvasPoint;
        coin.Construct(money, _coinsPoint);
        coin.TargetAchieved += OnCoinTargetAchieved;
    }


    private void OnCoinTargetAchieved(int countMoney, Coin coin)
    {
        coin.TargetAchieved -= OnCoinTargetAchieved;
        Destroy(coin.gameObject);
        _playerWallet.AddMoney(countMoney);
    }
}
