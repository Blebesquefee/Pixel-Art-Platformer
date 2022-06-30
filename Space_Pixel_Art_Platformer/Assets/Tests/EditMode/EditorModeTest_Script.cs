using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EditorModeTest_Script
{
    [Test]
    public void GameObject_CreatedWithGiven_WillHaveTheName()
    {
        var go = new GameObject("Hero");
        Assert.AreEqual("Hero", go.name);
    }
}
