using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SQLTests
{
    string connectionString = "Server=213.136.93.171;Database=ki12058376_shooladventure;User Id=ki12058376_game;Password=aczQj2ShNb4wZzmV";
    [Test]
    public void DBPingTest()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        connection.Open();
        Assert.True(connection.Ping());
        connection.Close();
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
