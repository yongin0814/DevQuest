using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateData", order = int.MaxValue)]

public class ItemData : ScriptableObject
{
    [SerializeField] // �̸�
    private string itemName;
    public string Name { get { return itemName; } set { itemName = value; } }

    [SerializeField] // ������ �ö󰡴� �ı���
    private int hitdamage;
    public int HitDamage { get { return hitdamage; } set { hitdamage = value; } }


    [SerializeField] // ������ �ö󰡴� ���ǵ� 
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    //[SerializeField] // VFX
    public GameObject vfx;






}


