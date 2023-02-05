using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlatform : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    CharacterObject player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterObject>();
    if (player.treeList.Count == player.maxTrees)
    {
      TreePlatform goner = player.treeList[0];
      player.treeList.RemoveAt(0);
      Destroy(goner.gameObject);
    }

    player.treeList.Add(this);
  }
}
