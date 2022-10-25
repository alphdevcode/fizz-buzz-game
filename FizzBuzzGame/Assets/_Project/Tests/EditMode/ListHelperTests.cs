using System.Collections.Generic;
using AlphDevCode.Utilities;
using NUnit.Framework;

namespace Tests
{
    public class ListHelperTests
    {
        private readonly List<int> _list = new List<int> { 1, 2, 3, 4, 5 };

        [Test]
        public void Given_ListItem_Then_NextItem([Range(0, 3)] int index)
        {
            int item = _list[index];
            Assert.AreEqual(_list[index+1],_list.GetItemAfter(item));
        }

        [Test]
        public void Given_ListItem_Then_PreviousItem([Range(1, 4)] int index)
        {
            int item = _list[index];
            Assert.AreEqual(_list[index-1],_list.GetItemBefore(item));
        }
        
        [Test]
        public void Given_LastListItem_Then_NextItemIsFirstItem()
        {
            int item = _list[^1];
            Assert.AreEqual(_list[0],_list.GetItemAfter(item));
        }
        
        [Test]
        public void Given_ListFirstItem_Then_PreviousItemIsLastItem()
        {
            int item = _list[0];
            Assert.AreEqual(_list[^1],_list.GetItemBefore(item));
        }
    }
}