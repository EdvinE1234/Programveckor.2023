using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator _animator;
    public AudioSource fortnite;

    // för att animera dörrarna - hugo
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Open")]
    public void Open()
    {
        _animator.SetTrigger(name: "Open");

        fortnite.Play();
    }
}
