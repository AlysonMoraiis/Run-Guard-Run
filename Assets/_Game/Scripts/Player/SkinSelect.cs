using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkinSelect : MonoBehaviour, ISaveable
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private RuntimeAnimatorController[] playerController;
    [SerializeField] private Sprite[] playerRenderer;
    public int _index;
    public event Action OnEquip;

    private void Start()
    {
        Debug.Log("a index é: " + _index);
        SetPlayerSelected(_index);
    }

    public void SetPlayerSelected(int index)
    {
        _index = index;
        spriteRenderer.sprite = playerRenderer[index];
        animator.runtimeAnimatorController = playerController[index];
        SaveLoadSystem.Instance.Save();
        OnEquip?.Invoke();
        Debug.Log(_index);
    }

    public object SaveState()
    {
        Debug.Log(_index);
        return new SaveData()
        {
            index = this._index
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        _index = saveData.index;
        Debug.Log(_index);
    }

    [Serializable]
    private struct SaveData
    {
        public int index;
    }
}
