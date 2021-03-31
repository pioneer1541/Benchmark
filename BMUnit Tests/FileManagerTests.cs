using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benchmark;
using System.Windows;
using System.Collections;

namespace BMUnit_Tests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FileManagerTest_Save_List()
        {
            //Creating some test data for simulating recent list.
            Point new_pt = new Point(55, 65);
            ArrayList Recent_List = new ArrayList();
            MyClass cows = new MyClass("cows", "cow", new_pt, -4, -6, "LeftDown");
            MyClass horse = new MyClass("horse", "horse", new_pt, -4, -6, "LeftDown");
            MyClass deer = new MyClass("deer", "deer", new_pt, -4, -6, "LeftDown");
            MyClass dragon = new MyClass("dragon", "dragon", new_pt, -4, -6, "LeftDown");
            Recent_List.Add(cows);
            Recent_List.Add(horse);
            Recent_List.Add(deer);
            Recent_List.Add(dragon);

            ArrayList RecentList = new ArrayList();
            RecentList.Add(cows.context);
            RecentList.Add(deer.context);
            RecentList.Add(dragon.context);
            RecentList.Add(horse.context);

            //Testing if the Save_List run correctly.
            FileManager file = new FileManager(RecentList);
            file.Save_List();
            Assert.IsTrue(file.Save_List());
        }

        [TestMethod]
        public void FileManagerTest_Load_List()
        {
            //Creating some test data for simulating recent list.
            Point new_pt = new Point(55, 65);
            ArrayList Recent_List = new ArrayList();
            MyClass cows = new MyClass("cows", "cow", new_pt, -4, -6, "LeftDown");
            MyClass horse = new MyClass("horse", "horse", new_pt, -4, -6, "LeftDown");
            MyClass deer = new MyClass("deer", "deer", new_pt, -4, -6, "LeftDown");
            MyClass dragon = new MyClass("dragon", "dragon", new_pt, -4, -6, "LeftDown");
            Recent_List.Add(cows);
            Recent_List.Add(horse);
            Recent_List.Add(deer);
            Recent_List.Add(dragon);

            ArrayList RecentList = new ArrayList();
            RecentList.Add(cows.context);
            RecentList.Add(deer.context);
            RecentList.Add(dragon.context);
            RecentList.Add(horse.context);

            //Testing if the Save_List run correctly.
            FileManager file = new FileManager(RecentList);
            Assert.IsTrue(file.Load_List(0));
            Assert.IsTrue(file.Load_List(1));
        }
    }
}
