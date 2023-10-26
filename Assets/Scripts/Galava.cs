using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Galava : MonoBehaviour
{
    [SerializeField] private float _ohjik;
    [SerializeField] private Nazhiv _nazhivs;
    [SerializeField] private Sprite[] _hihimr;

    [SerializeField] private TMP_Text _jumba;
    [SerializeField] private TMP_Text _jingas;

    private List<Nazhiv> _nazhiviusss = new();

    private int _curJumba;

    private void Awake()
    {
        _ohjik += transform.localScale.x;
        PognaliIgrassa();

        _hikTuk = StartCoroutine(HikTuk());
        _jingas.SetText($"Score: {_curJumba}");
    }

    private Nazhiv _curNazhiv;

    private void ProverOchka(Nazhiv nazhiv)
    {
        if (_curNazhiv == null)
        {
            _curNazhiv = nazhiv;
            return;
        }

        var ufsha = _curNazhiv;
        _curNazhiv = null;

        if (ufsha.HiD == nazhiv.HiD)
        {
            ufsha.Voshiv -= ProverOchka;
            nazhiv.Voshiv -= ProverOchka;

            _nazhiviusss.Remove(ufsha);
            _nazhiviusss.Remove(nazhiv);

            _curJumba++;
            _jingas.SetText($"Score: {_curJumba}");
        }
        else
        {
            Shinob(ufsha, nazhiv);
        }

        if (_nazhiviusss.Count == 0)
        {
            PrePognali();
        }
    }

    private Coroutine _hikTuk;

    private IEnumerator HikTuk()
    {
        var hjkl = 60;
        while (hjkl > 0)
        {
            
            yield return new WaitForSecondsRealtime(1f);
            hjkl--;
            _jumba.SetText($"Time: {hjkl} sec");
        }
        
        StopCoroutine(_hikTuk);
        PlayerPrefs.SetInt("shokl", _curJumba);
        _vme = true;
        SceneManager.LoadScene(2);
    }

    private bool _vme;
    
    private async void PrePognali()
    {
        await Task.Delay(1000);
        if (_vme)
            return;

        var hurmand = GetComponentsInChildren<Nazhiv>();
        foreach (var nazhiv1 in hurmand)
            nazhiv1.LastUbral();

        await Task.Delay(250);

        foreach (var nazhiv1 in hurmand)
            Destroy(nazhiv1.gameObject);

        PognaliIgrassa();
    }

    private void PognaliIgrassa()
    {
        FiFaFo(_hihimr);

        _nazhiviusss.Clear();
        var bibibo = (Vector2)transform.position;
        for (var ochu = 0; ochu < Mathf.Min(_hihimr.Length, 3); ochu++)
        {
            for (var piv = 0; piv < 2; piv++)
            {
                if (ochu == 1 && piv == 1)
                {
                    bibibo.x = transform.position.x;
                    bibibo.y -= 2f + _ohjik;
                }

                var ircha = Instantiate(_nazhivs, bibibo, Quaternion.identity, transform);
                bibibo.x += ircha.transform.localScale.x + _ohjik;
                ircha.Ustanovochka(_hihimr[ochu], ochu);
                ircha.Voshiv += ProverOchka;
                _nazhiviusss.Add(ircha);
            }
        }

        var swishNaz = _nazhiviusss.Count;
        while (1 < swishNaz)
        {
            var sluchka = new System.Random()
                .Next(swishNaz--);
            (_nazhiviusss[swishNaz].transform.position, _nazhiviusss[sluchka].transform.position) = (
                _nazhiviusss[sluchka].transform.position, _nazhiviusss[swishNaz].transform.position);
        }
    }

    private void FiFaFo<T>(T[] kimJin)
    {
        var fghjkl = kimJin.Length;
        while (1 < fghjkl)
        {
            var jkhg = new System.Random()
                .Next(fghjkl--);
            (kimJin[fghjkl], kimJin[jkhg]) = (kimJin[jkhg], kimJin[fghjkl]);
        }
    }

    private async void Shinob(Nazhiv aNaz, Nazhiv bNaz)
    {
        await Task.Delay(250);
        aNaz.Ubral();
        bNaz.Ubral();
    }
}