using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Compression.Tests.Common.Payloads;

namespace Microsoft.AspNet.SignalR.Compression.Tests.Common.Utilities
{
    public static class TestData
    {
        public static object[] GetNonCompressableDataSet()
        {
            return new object[] 
            {
                "foo",
                "",
                long.MaxValue,
                long.MinValue,
                int.MaxValue,
                short.MaxValue,
                byte.MaxValue,
                double.MaxValue,
                decimal.MaxValue,
                new
                {
                    Foo = "bar",
                    Bar = 1337
                },
                true,
                false,
                null
            };
        }

        public static object[] GetCompressableGenericDataSet()
        {
            return new object[]
            {
                new Event<IList<EventData<string>>>()
                {
                    EventId = 5,
                    EventData = new List<EventData<string>>()
                    {
                        new EventData<string> { Property = "Prop1"},
                        new EventData<string> { Property = "Prop2"},
                        new EventData<string> { Property = "Prop3"},
                    }
                },
                new Event<IList<EventData<string>>>()
                {
                    EventId = 1,
                    EventData = new List<EventData<string>>()
                    {
                        new EventData<string> { Property = "E1Prop1"},
                    }
                },
                new Event<IList<EventData<string>>>()
                {
                    EventData = new List<EventData<string>>()
                    {
                        new EventData<string> { Property = "E0Prop1"},
                    }
                },
            };

        }

        public static object[] GetExpectedCompressableGenericDataSetResult()
        {
            return new object[]
            {
                // Event
                new object[] 
                {
                    // Event Data List
                    new object[]
                    {
                        // Event Data
                        new object[] {"Prop1"},
                        new object[] {"Prop2"},
                        new object[] {"Prop3"},
                    }, 
                    // EventId
                    5
                },
                // Event
                new object[] 
                {
                    // Event Data List
                    new object[]
                    {
                        // Event Data
                        new object[] {"E1Prop1"},
                    }, 
                    // EventId
                    1
                },
                // Event
                new object[] 
                {
                    // Event Data List
                    new object[]
                    {
                        // Event Data
                        new object[] {"E0Prop1"},
                    }
                }
            };
        }

        public static object[] GetCompressableDataSet()
        {
            return new object[] 
            {
                new Parent
                {
                    Mother = new Parent
                    {
                        FirstName = "Mom",
                        Age = 62
                        // TODO: Allow for semi-recursive loops, aka adding the top level parent as a Child of "Mom"
                    },
                    FirstName = "John",
                    LastName = "Doe",
                    Age = 36,
                    Children = new Person[]{
                        new Person
                        {
                            FirstName="Daughter",
                            LastName="Doe",
                            Age=9
                        },
                        new Person
                        {
                            FirstName="Johny",
                            LastName="Doe",
                            Age=7
                        }
                    }
                },
                new Person
                {
                    FirstName="John",
                    LastName="Doe",
                    Age=1337
                },
                new Person[] {
                    new Person
                    {
                        FirstName="Uno",
                    },
                    new Person
                    {
                        LastName="Dos"
                    }
                }
            };
        }

        public static object[] GetExpectedCompressableDataSetResult()
        {
            return new object[] 
            {
                new object[] {36,new object[] {new object[] {9,"Daughter",0,"Doe"},new object[] {7,"Johny",0,"Doe"}},"John",0,"Doe",new object[] {62,0,"Mom",0,0,0}},
                new object[] {1337,"John", 0, "Doe"},
                new object[] {new object[] {0,"Uno",0,0}, new object[] {0,0,0,"Dos"}}
            };
        }
    }
}
