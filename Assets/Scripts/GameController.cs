using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _inventorySlots;
    [SerializeField] private int _currentSlots;
    [SerializeField] private int _timer;
    [SerializeField] private Text _timerText;
    [SerializeField] private int _deathTimeSec;
    [SerializeField] private int _collectTimeSec;
    [SerializeField] private int _score;
    [SerializeField] private Text _backPackText;
    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Text _totalScore;

    private void Update()
    {
        if(_timer <= 0)
        {
            GameOver();
        }
    }
    private void Start()
    {
        _backPackText.text = _currentSlots + "/" + _inventorySlots;
        StartCoroutine(WaitAndPrint());
    }

    public void CollectItem(GameObject enemy)
    {
        if(_currentSlots < _inventorySlots)
        {
            _currentSlots++;
            _backPackText.text = _currentSlots + "/" + _inventorySlots;
            Debug.Log(_currentSlots + " / " + _inventorySlots);
            Destroy(enemy);
        }
    }

    public void DropItemsToBox()
    {
        _timer += _currentSlots * _collectTimeSec;
        _score += _currentSlots;
        _scoreText.text = _score.ToString();
        _currentSlots = 0;
        _backPackText.text = _currentSlots + "/" + _inventorySlots;
    }

    public void NotCollectItem()
    {
        _timer -= _deathTimeSec;
    }

    public void GameOver()
    {
        _totalScore.text = _score.ToString();
        _gameOverScreen.SetActive(true);
        _gameOverScreen.GetComponent<CanvasGroup>().DOFade(1, 1);
    }

    IEnumerator WaitAndPrint()
    {
        while (true)
        {
            if (_timer > 0)
            {
                _timer--;
                _timerText.text = _timer.ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                _timerText.text = "0";
            }

            yield return null;
        }
    }
}
