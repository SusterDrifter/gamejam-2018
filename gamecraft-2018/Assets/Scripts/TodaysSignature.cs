using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodaysSignature
{
    private static TodaysSignature instance;

    public string signature;
    private TodaysSignature() {
        string[] signatures = {
            "abcd", "abdc", "acbd", "acdb", "adbc", "adcb",
            "bacd", "badc", "bcad", "bcda", "bdac", "bdca",
            "cabd", "cadb", "cbad", "cbda", "cdab", "cdba",
            "dabc", "dacb", "dbac", "dbca", "dcab", "dcba"
        };
        int r = Random.Range(0, 24);
        signature = signatures[r];
    }

    public static TodaysSignature GetInstance() {
        if (instance == null) instance = new TodaysSignature();
        return instance;
    }

}
