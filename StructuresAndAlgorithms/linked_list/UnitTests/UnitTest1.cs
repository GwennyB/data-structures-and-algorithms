using System;
using Xunit;
using linked_list.Classes;

namespace UnitTests
{
    public class UnitTest1
    {
        /// <summary>
        /// Verifies that new nodes are created with values properly assigned at instantiation.
        /// </summary>
        /// <param name="value"> test value to assign to Node.Value </param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(1.111111)]
        public void Node_CreatesNewNode(int value)
        {
            Node testNode = new Node(value);
            Assert.Equal(value, testNode.Value);
        }

        /// <summary>
        /// Verifies that new nodes are created, added to linked list, and assigned as 'Head'.
        /// </summary>
        /// <param name="value"> test value to assign to Node.Value </param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(1.111111)]
        public void Insert_AddsNodeWithThisValue(int value)
        {
            LinkedList testList = new LinkedList();
            testList.Insert(value);
            Assert.Equal(value, testList.Head.Value);
        }

        /// <summary>
        /// Verifies that new node is 'Head' and points to the last created node as 'Next' 
        /// </summary>
        [Fact]
        public void Insert_AssignsNext()
        {
            LinkedList testList = new LinkedList();
            testList.Insert(555);
            testList.Insert(888);
            Assert.Equal(555, testList.Head.Next.Value);
        }

        /// <summary>
        /// Verifies that node is created and subsequently located by value
        /// </summary>
        /// <param name="value"> test value to assign to new node and find in list </param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(1.111)]
        public void Includes_ReturnsTrueForListWithSingleNode(Object value)
        {
            LinkedList testList = new LinkedList();
            testList.Insert(value);
            Assert.True(testList.Includes(value));
        }

        /// <summary>
        /// Verifies that Includes can locate a value in a linked list with multiple nodes
        /// </summary>
        /// <param name="value"> value to find in linked list </param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(1.1)]
        public void Includes_ReturnsTrueForListWithManyNodes(Object value)
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 0, 1, 100, -1, -100, 1.1 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            Assert.True(testList.Includes(value));
        }

        /// <summary>
        /// Verifies that Includes returns 'false' when value does not exist in list
        /// </summary>
        [Fact]
        public void Includes_ReturnsFalseForListWithManyNodes()
        {
            LinkedList testList = new LinkedList();
            int number = Convert.ToInt32(1.1);
            int[] testPoints = new int[] { 0, 1, 100, -1, -100, number };
            foreach (int point in testPoints)
            {
                testList.Insert(point);
            }
            Assert.False(testList.Includes(88));
        }

        /// <summary>
        /// Verifies that InsertBefore inserts a new node in the correct location
        /// </summary>
        [Fact]
        public void InsertBefore_InsertsInCorrectSlot()
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 0, 1, 100, -1, -100 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            testList.InsertBefore(1, 88);
            Assert.Equal(88,testList.Current.Next.Value);
        }

        /// <summary>
        /// Verifies that InsertBefore inserts a new node at Head location
        /// </summary>
        [Fact]
        public void InsertBefore_InsertsNewHead()
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 0, 1, 100, -1, -100 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            testList.InsertBefore(-100, 88);
            Assert.Equal(88, testList.Head.Value);
        }
        
        /// <summary>
        /// Verifies that InsertAfter inserts a new node in the correct location
        /// </summary>
        [Fact]
        public void InsertAfter_InsertsInCorrectSlot()
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 0, 1, 100, -1, -100 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            testList.InsertAfter(1, 88);
            Assert.Equal(88, testList.Current.Next.Value);
        }

        /// <summary>
        /// Verifies that InsertAfter inserts a new node in the correct location
        /// </summary>
        [Fact]
        public void InsertAfter_InsertsAtEnd()
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 0, 1, 100, -1, -100 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            testList.Current = testList.Head;
            while (testList.Current.Next != null)
            {
                testList.Current = testList.Current.Next;
            }
            testList.InsertAfter(0, 88);
            Assert.Equal(88, testList.Current.Next.Value);
        }

        /// <summary>
        /// Verifies that Append inserts a new node at the end of the list
        /// </summary>
        [Fact]
        public void Append_InsertsAtEnd()
        {
            LinkedList testList = new LinkedList();
            int[] testPoints = new int[] { 0, 1, 100, -1, -100 };
            foreach (int point in testPoints)
            {
                testList.Insert(point);
            }
            testList.Append(88);
            testList.Current = testList.Current.Next;
            Assert.Equal(88, testList.Current.Value);
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(5, 1)]
        [InlineData(6, null)]
        public void FindFromEnd(int k, Object value)
        {
            LinkedList testList = new LinkedList();
            Object[] testPoints = new Object[] { 6, 5, 4, 3, 2, 1 };
            foreach (Object point in testPoints)
            {
                testList.Insert(point);
            }
            Assert.Equal(value, testList.FindFromEnd(k));
        }

    }
}
