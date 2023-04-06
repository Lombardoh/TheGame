using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemData : ScriptableObject {
  public List<Item> items = new List<Item>();

  public Item ItemOfType(ItemType itemType){
    return items[(int)itemType];
  }
}

