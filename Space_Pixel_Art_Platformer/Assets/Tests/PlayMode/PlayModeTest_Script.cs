using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Test
{
    public class PlayModeTest_Script
    {
        [Test]
        public void Increment()
        {
            var counter = 0;
            counter += 1;
            Assert.AreEqual(1, counter);
        }
        
        [Test]
        public void Sceneloading()
        {
            SceneManager.LoadScene("Easy");
            var sc = SceneManager.GetActiveScene().isLoaded;
            Assert.AreEqual(true, sc);
        }

        [UnityTest]
        public IEnumerator GameObject_WithRigidBody_WillBeAffectedByPhysics()
        {
            var go = new GameObject("Hero");
            go.AddComponent<Rigidbody>();
            var originalPosition = go.transform.position.y;
    
            yield return new WaitForFixedUpdate();

            Assert.AreNotEqual(originalPosition, go.transform.position.y);
        }
    }
}
