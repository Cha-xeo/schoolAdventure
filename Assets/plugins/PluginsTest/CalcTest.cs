using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Expression = NCalc.Expression;
public class CalcTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void CalcTestSimpleAddition()
    {
        Expression expression = new Expression("1+1");
        Assert.AreEqual((int)expression.Evaluate(), 2);
    }
    [Test]
    public void CalcTestSimpleSoustraction()
    {
        Expression expression = new Expression("1-1");
        Assert.AreEqual((int)expression.Evaluate(), 0);
    }
    [Test]
    public void CalcTestSimpleDivision()
    {
        Expression expression = new Expression("2/1");
        Assert.AreEqual(expression.Evaluate(), 2);
    }
    [Test]
    public void CalcTestSimpleDivisionByMultiply()
    {
        Expression expression = new Expression("2*0.5");
        Assert.AreEqual(expression.Evaluate(), 1);
    }
    [Test]
    public void CalcTestSimpleMultiplication()
    {
        Expression expression = new Expression("1*1");
        Assert.AreEqual((int)expression.Evaluate(), 1);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    /*[UnityTest]
    public IEnumerator CalcTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }*/
}
