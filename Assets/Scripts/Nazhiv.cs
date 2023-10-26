using System;
using UnityEngine;

public class Nazhiv : MonoBehaviour
{
    [SerializeField] private Animator _shvarts;
    [SerializeField] private SpriteRenderer _virisovkin;
    private static readonly int Pokazh = Animator.StringToHash("Show");
    private static readonly int UnPokazh = Animator.StringToHash("Hide");

    public int HiD { get; private set; }

    public void Ustanovochka(Sprite vuv, int hId)
    {
        _virisovkin.sprite = vuv;
        HiD = hId;
    }
    
    private bool _shpruk;
    public bool OverNec { get; set; }

    private void OnMouseUpAsButton()
    {
        if (_shpruk || OverNec)
            return;
        
        _shpruk = true;
        _shvarts.SetTrigger(Pokazh);
        Voshiv?.Invoke(this);
    }

    public event Action<Nazhiv> Voshiv;

    public void Ubral()
    {
        if (!_shpruk)
            return;
        
        _shpruk = false;
        LastUbral();
    }

    public void LastUbral()
    {
        _shvarts.SetTrigger(UnPokazh);
    }
}
