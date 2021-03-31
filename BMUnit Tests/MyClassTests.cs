using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benchmark;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Input;

namespace MyClassTests
{
    [TestClass]
    public class AnimalUnitTest
    {
        /*
         * set up a few properties for the tests of MyClass.
        */
        static public Point pt = new Point(50, 60);
        static public string type = "cows";
        static public MyClass test = new MyClass(type, type + "_01", pt);
        [TestMethod]
        public void AnimalTest_Name()
        {
            //test if it is correct to set a name-value to an object of the MyClass.
            Assert.AreEqual("cows_01",test.Name);
        }

        [TestMethod]
        public void AnimalTest_Tag()
        {
            //test if the Tag property is correct while constructing a new object of the MyClass.
            if (test.Tag.ToString() != "RightDown" && test.Tag.ToString() != "RightUp" && test.Tag.ToString() != "LeftDown" && test.Tag.ToString() != "LeftUp")
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void AnimalTest_speedX()
        {
            //test if it is correct to set a speedX-value to an object of the MyClass.
            test.speedX = -6;
            Assert.AreEqual(-6, test.speedX);
        }
        [TestMethod]
        public void AnimalTest_speedY()
        {
            //test if it is correct to set a speedY-value to an object of the MyClass.
            test.speedY = -6;
            Assert.AreEqual(-6, test.speedY);
        }
        [TestMethod]
        public void AnimalTest_context()
        {
            ////test if the context-value is generated correctly when constructing a new object of the MyClass.
            Point new_pt = new Point(55, 65);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "LeftDown");
            Assert.AreEqual("test, X Speed:-4, Y Speed:-6, Location:55,65, Direction:LeftDown", test1.context);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_RightUpToLeftUp()
        {
            //When the X point location greater than 390 and tag content saying the strategy right now is RightUp, Turning the strategy to LeftUp by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(420, 65);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "RightUp");
            test1.Animation_Move(sender,e);
            Assert.AreEqual("LeftUp", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_RightDownToLeftDown()
        {
            //When the X point location is greater than 390 and tag content saying the strategy right now is RightDown, Turning the strategy to LeftDown by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(420, 36);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "RightDown");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("LeftDown", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_LeftUpToRightUp()
        {
            //When the X point location is less than 2 and tag content saying the strategy right now is LeftUp, Turning the strategy to RightUp by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(0, 200);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "LeftUp");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("RightUp", test1.Tag);
        }

        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_LeftDownToRightDown()
        {
            //When the X point location is less than 2 and tag content saying the strategy right now is LeftDown, Turning the strategy to RightDown by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(0, 200);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "LeftDown");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("RightDown", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_LeftDownToLeftUp()
        {
            //When the Y point location is greater than 340 and tag content saying the strategy right now is LeftDown, Turning the strategy to LeftUp by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(254, 360);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "LeftDown");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("LeftUp", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_RightDownToRightUp()
        {
            //When the Y point location is greater than 340 and tag content saying the strategy right now is RightDown, Turning the strategy to RightUp by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(254, 360);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "RightDown");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("RightUp", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_LeftUpToLeftDown()
        {
            //When the Y point location is less than 2 and tag content saying the strategy right now is LeftUp, Turning the strategy to LeftDown by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(40, 0);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "LeftUp");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("LeftDown", test1.Tag);
        }
        [TestMethod]
        public void AnimalTest_Animation_Move_Tag_RightUpToRightDown()
        {
            //When the Y point location is less than 2 and tag content saying the strategy right now is RightUp, Turning the strategy to RightDown by changing the tag.
            object sender = null;
            EventArgs e = null;
            Point new_pt = new Point(42, 0);
            MyClass test1 = new MyClass("cows", "test", new_pt, -4, -6, "RightUp");
            test1.Animation_Move(sender, e);
            Assert.AreEqual("RightDown", test1.Tag);
        }
    }
}
