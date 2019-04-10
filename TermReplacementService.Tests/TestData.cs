using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TermReplacementService.Tests
{
    public abstract class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator() => GetTestCases();        

        public abstract IEnumerator<object[]> GetTestCases();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
