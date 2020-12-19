using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    private SpeciesDictionary dictionary;
    private void Awake()
    {
        dictionary = new SpeciesDictionary();
    }
}
