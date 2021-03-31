using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benchmark;
using System.Windows;
using System.Collections.Generic;
using System.Linq;

namespace BMUnit_Tests
{
    [TestClass]
    public class FilterTests
    {

        [TestMethod]
        public void FilterTest_Search_List()
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
            Filter filter = new Filter(Recent_List);

            //Check if the Search_List() function return a correct result.
            Assert.AreEqual(horse.context, filter.Search_List("horse")[0]);
        }

        [TestMethod]
        public void FilterTest_Sort_ListZA()
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

            //Adding string object which is ordered by Z-A to a list.
            ArrayList ExpectList = new ArrayList();
            ExpectList.Add(horse.context);
            ExpectList.Add(dragon.context);
            ExpectList.Add(deer.context);
            ExpectList.Add(cows.context);

            //loop the list of ExpectList to check if the result get from the Sort_ListZA function is correct.
            Filter filter = new Filter(Recent_List);
            ArrayList Actual_List = filter.Sort_ListZA();
            int num = 0;
            foreach (var i in ExpectList)
            {
                Assert.AreEqual(i, Actual_List[num]);
                num++;
            }
        }

        [TestMethod]
        public void FilterTest_Sort_ListAZ()
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

            //Adding string object which is ordered by A-Z to a list.
            ArrayList ExpectList = new ArrayList();
            ExpectList.Add(cows.context);
            ExpectList.Add(deer.context);
            ExpectList.Add(dragon.context);
            ExpectList.Add(horse.context);

            //loop the list of ExpectList to check if the result get from the Sort_ListAZ function is correct.
            Filter filter = new Filter(Recent_List);
            ArrayList Actual_List = filter.Sort_ListAZ();
            int num = 0;
            foreach (var i in ExpectList)
            {
                Assert.AreEqual(i, Actual_List[num]);
                num++;
            }
        }
    }
}
