using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Fish", menuName = "Fish/New Fish")]
public class FishBase : ScriptableObject
{
    [SerializeField] public string nama;
    [SerializeField] public float laju;
    [SerializeField] public int level;
    [SerializeField] public Sprite image;
}
