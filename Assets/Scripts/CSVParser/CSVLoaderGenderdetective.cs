using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using yutokun;

public class CSVLoaderGenderdetective
{
    [SerializeField] TextAsset[] CSVAsset;
    public List<List<string>> sheet = new List<List<string>>();
    int index = -1;
    private void Initialize()
    {
        index = (int)Mathf.Repeat(index + 1, CSVAsset.Length);
        sheet = CSVParser.LoadFromString(CSVAsset[index].text);
    }
}
