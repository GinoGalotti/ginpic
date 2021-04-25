using NUnit.Framework;
using System;
using System.IO;

namespace BugHunt.Tests
{
    public class BugHunt_Tests
    {
        private MyList l;

        [Test] 
        public void BugHunt_AddOnEmpty()
        {
            l = new MyList();
            l.Add(1);
            Assert.AreEqual("{1}",l.ToString());

            l = new MyList();
            l.Add(0.1);
            Assert.AreEqual("{0.1}", l.ToString());

            l = new MyList();
            l.Add('x');
            Assert.AreEqual("{x}", l.ToString());

            l = new MyList();
            l.Add(null);
            Assert.AreEqual("{}", l.ToString());
        }

        [Test] 
        public void BugHunt_AddSeveral()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            l.Add('x');
            Assert.AreEqual("{1,0.1,4,aa,0,x}",l.ToString());
        }

        [Test] 
        public void BugHunt_LastOnEmpty()
        {
            l = new MyList();
            Assert.AreEqual(null,l.Last());
        }
        [Test] 
        public void BugHunt_LastOnOneMember()
        {
            l = new MyList();
            l.Add(1);
            Assert.AreEqual("{Data: 1, Next: null}",l.Last().ToString());

            l = new MyList();
            l.Add(0.1);
            Assert.AreEqual("{Data: 0.1, Next: null}", l.Last().ToString());
        }
        [Test] 
        public void BugHunt_LastOnManyMembers()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            l.Add('x');
            Assert.AreEqual("{Data: x, Next: null}",l.Last().ToString());
        }

        [Test] 
        public void BugHunt_AddHeadOnEmpty()
        {
            l = new MyList();
            l.AddHead(1);
            Assert.AreEqual("{1}",l.ToString());

            l = new MyList();
            l.AddHead(0.1);
            Assert.AreEqual("{0.1}", l.ToString());

            l = new MyList();
            l.AddHead('x');
            Assert.AreEqual("{x}", l.ToString());

            l = new MyList();
            l.AddHead(null);
            Assert.AreEqual("{}", l.ToString());
        }

        [Test] 
        public void BugHunt_DeleteWhenHaving1()
        {
            l = new MyList();
            l.Add(1);
            l.Delete(0);
            Assert.AreEqual(0,l.Length);
        }

        [Test] 
        public void BugHunt_DeleteOutOfBounds()
        {
            l = new MyList();
            l.Add(1);
            l.Delete(1);
            Assert.AreEqual(1,l.Length);
        }

        [Test] 
        public void BugHunt_DeleteWhenEmpty()
        {
            l = new MyList();
            l.Delete(0);
            Assert.AreEqual(null,l.Head);
        }

        [Test] 
        public void BugHunt_DeleteWhenFirst()
        {
            l = new MyList();
            l.Add(1);
            l.Add(2);
            l.Delete(0);
            Assert.AreEqual("{2}",l.ToString());
        }

        [Test] 
        public void BugHunt_DeleteWhenNotLast()
        {
            l = new MyList();
            l.Add(1);
            l.Add(2);
            l.Add(3);
            l.Delete(1);
            Assert.AreEqual("{1,3}",l.ToString());
        }

        [Test] 
        public void BugHunt_PopWhenEmpty()
        {
            l = new MyList();
            Node pop = l.Pop();
            Assert.AreEqual(null,pop);
        }

        [Test] 
        public void BugHunt_PopWhenOneMember()
        {
            l = new MyList();
            l.Add(1);
            Node pop = l.Pop();
            Assert.AreEqual("{Data: 1, Next: null}", pop.ToString());
            Assert.AreEqual(0, l.Length);
        }

        [Test] 
        public void BugHunt_PopWhenManyMembers()
        {
            l = new MyList();
            l.Add(1);
            l.Add(2);
            Node pop = l.Pop();
            Assert.AreEqual("{Data: 2, Next: null}", pop.ToString());
            Assert.AreEqual(1, l.Length);
        }

        [Test] 
        public void BugHunt_LengthOfZero()
        {
            l = new MyList();
            Assert.AreEqual(0,l.Length);
        }

        [Test] 
        public void BugHunt_LengthOfOne()
        {
            l = new MyList();
            l.Add(1);
            Assert.AreEqual(1,l.Length);
        }
        
        [Test] 
        public void BugHunt_LengthOfMany()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            l.Add('x');
            Assert.AreEqual(6,l.Length);
        }

        [Test] 
        public void BugHunt_FindOnEmpty()
        {
            l = new MyList();
            Assert.AreEqual(null,l.Find("x"));
        }

        [Test] 
        public void BugHunt_FindSuccess()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            l.Add("x");
            Assert.AreEqual("{Data: x, Next: null}",l.Find("x").ToString());
        }

        [Test] 
        public void BugHunt_FindFail()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            l.Add("x");
            Assert.AreEqual(null,l.Find("y"));
        }

        [Test] 
        public void BugHunt_InsertMemberOnEmpty()
        {
            l = new MyList();
            Node inserting = new Node();
            inserting.Data = "x";
            inserting.Next = null;
            l.Insert(1,inserting);
            Assert.AreEqual("{x}",l.ToString());
        }

        [Test] 
        public void BugHunt_InsertOnLast()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            Node inserting = new Node();
            inserting.Data = "x";
            inserting.Next = null;
            l.Insert(5, inserting);
            Assert.AreEqual("{1,0.1,4,aa,0,x}",l.ToString());
        }

        [Test] 
        public void BugHunt_InsertInBetween()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            Node inserting = new Node();
            inserting.Data = "x";
            inserting.Next = null;
            l.Insert(3, inserting);
            Assert.AreEqual("{1,0.1,4,x,aa,0}",l.ToString());
        }

        [Test] 
        public void BugHunt_InsertList()
        {
            l = new MyList();
            l.Add(1);
            l.Add(0.1);
            l.Add(4);
            l.Add("aa");
            l.Add(0);
            Node inserting2 = new Node();
            inserting2.Data = "y";
            inserting2.Next = null;
            Node inserting = new Node();
            inserting.Data = "x";
            inserting.Next = inserting2;
            l.Insert(3, inserting);
            Assert.AreEqual("{1,0.1,4,x,y,aa,0}",l.ToString());
        }
        
        [Test] 
        public void BugHunt_PrintAll()
        {
            TextWriter originalOut = Console.Out;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                l = new MyList();
                l.Add(1);
                l.Add(4);
                l.Add(9);
                l.Add("aa");
                Assert.AreEqual("{1,4,9,aa}",l.ToString());

                l.PrintAll();
                Assert.AreEqual("1\r\n4\r\n9\r\naa\r\n\r\n", sw.ToString());
            }
            Console.SetOut(originalOut);
        }

    }
}