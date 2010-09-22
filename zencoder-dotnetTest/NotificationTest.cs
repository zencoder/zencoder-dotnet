using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZencoderDotNet.Api;

namespace ZencoderDotNetTest
{
    [TestClass]
    public class NotificationTest
    {
       
        [TestMethod]
        public void TestDeserializeXml()
        {
            string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                           <hash>
                             <job>
                               <state>finished</state>
                               <test type=""boolean"">true</test>
                               <id type=""integer"">32510</id>
                             </job>
                             <output>
                               <state>finished</state>
                               <url>https://example.com</url>
                               <label nil=""true""></label>
                               <id type=""integer"">35407</id>
                             </output>
                           </hash>";

            Notification notification = Notification.deserialize(xml, "xml");

            Assert.AreEqual("finished", notification.job.state);
            Assert.AreEqual(true, notification.job.test);
            Assert.AreEqual(32510, notification.job.id);
            Assert.AreEqual("finished", notification.output.state);
            Assert.AreEqual("https://example.com", notification.output.url);
            Assert.AreEqual("", notification.output.label);
            Assert.AreEqual(35407, notification.output.id);
        }

        [TestMethod]
        public void TestDeserializeJSON()
        {
            string json = @"{
                             ""job"":{
                                ""state"":""finished"",
                                ""test"":true,
                                ""id"":32514
                              },
                             ""output"":{
                                ""state"":""finished"",
                                ""url"":""https://example.com"",
                                ""label"":null,
                                ""id"":35411
                              }
                            }";

            Notification notification = Notification.deserialize(json, "json");

            Assert.AreEqual("finished", notification.job.state);
            Assert.AreEqual(true, notification.job.test);
            Assert.AreEqual(32514, notification.job.id);
            Assert.AreEqual("finished", notification.output.state);
            Assert.AreEqual("https://example.com", notification.output.url);
            Assert.AreEqual(null, notification.output.label);
            Assert.AreEqual(35411, notification.output.id);
        }
    }
}
