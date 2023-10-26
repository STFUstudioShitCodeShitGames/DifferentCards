using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shiburnov : MonoBehaviour
{
    [SerializeField] private TMP_Text _shok;
    [SerializeField] private TMP_Text _shokLuchs;

    private void Awake()
    {
        if (_shok == null)
            return;

        var shokl = PlayerPrefs.GetInt("shokl");
        var shokBe = PlayerPrefs.GetInt("shokBe");
        _shok.text = $"Score: {shokl}";

        if (shokl > shokBe)
        {
            PlayerPrefs.SetInt("shokBe", shokl);
            shokBe = shokl;
        }
        
        _shokLuchs.SetText($"Best score: {shokBe}");
    }

    public void CoMone(int juj)
    {
        SceneManager.LoadScene(juj);
    }

    public void KMamu()
    {
        Application.Quit();
    }
}