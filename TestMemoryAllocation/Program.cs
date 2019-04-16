using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestMemoryAllocation
{
    class Program
    {
        [Serializable]
        class TestObject
        {
            public string String { get; set; }
            public int I { get; set; } = 1;
            public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        }
        [Serializable]
        class TestObjectWithInstanceMethods
        {
            public string String { get; set; }
            public int I { get; set; } = 1;
            public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
            public void Method1() { }
            public void Method2() { }
            public void Method3() { }
            public void Method4() { }
            public void Method5() { }
            public void Method6() { }
            public void Method7() { }
            public void Method8() { }
            public void Method9() { }
            public void Method10() { }
        }

        [Serializable]
        class TestObjectWithStaticMethods
        {
            public string String { get; set; }
            public int I { get; set; } = 1;
            public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
            public static void Method1() { }
            public static void Method2() { }
            public static void Method3() { }
            public static void Method4() { }
            public static void Method5() { }
            public static void Method6() { }
            public static void Method7() { }
            public static void Method8() { }
            public static void Method9() { }
            public static void Method10() { }
        }


        [Serializable]
        class TestObjectRef
        {
            public TestObject Ref { get; set; }
            public int I { get; set; } = 1;
            public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        }

        static void Main(string[] args)
        {
            string ret = "";
            var objectCounts = new long[] { 10L, 1_000_000L };
            foreach (var objectCount in objectCounts)
            {
                Console.Write(ret += $"Going to create N objects: {objectCount}\n");
                var testStrings = new string[] { "", "1234567", "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" };
                foreach (var teststring in testStrings)
                {
                    Console.Write(ret += $"Testing with string: {teststring}\n");
                    #region Hashtable
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        Hashtable collection = new Hashtable();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection[i] = refAtStack;
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Hashtable<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        Hashtable collection = new Hashtable();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObjectWithInstanceMethods() { String = teststring };
                            refAtStack.String += "1";
                            collection[i] = refAtStack;
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Hashtable<TestObjectWithInstanceMethods>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        Hashtable collection = new Hashtable();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObjectWithStaticMethods() { String = teststring };
                            refAtStack.String += "1";
                            collection[i] = refAtStack;
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Hashtable<TestObjectWithStaticMethods>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };

                        Hashtable collection = new Hashtable();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection[i] = new TestObjectRef() { Ref = obj };
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Hashtable<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    #endregion
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new Dictionary<int, TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection[i] = new TestObject() { String = teststring };
                            collection[i].String += "1";
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Dictionary<int, TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };

                        var collection = new Dictionary<int, TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection[i] = new TestObjectRef() { Ref = obj };
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Dictionary<int, TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }


                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new ConcurrentDictionary<int, TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection[i] = new TestObject() { String = teststring };
                            collection[i].String += "1";
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentDictionary<int, TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };

                        var collection = new ConcurrentDictionary<int, TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection[i] = new TestObjectRef() { Ref = obj };
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentDictionary<int, TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new HashSet<TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection.Add(refAtStack);
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"HashSet<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };
                        var collection = new HashSet<TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection.Add(new TestObjectRef() { Ref = obj });
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"HashSet<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new ConcurrentBag<TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection.Add(refAtStack);
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentBag<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };
                        var collection = new ConcurrentBag<TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection.Add(new TestObjectRef() { Ref = obj });
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentBag<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new Queue<TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection.Enqueue(refAtStack);
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Queue<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };
                        var collection = new Queue<TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection.Enqueue(new TestObjectRef() { Ref = obj });
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"Queue<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new ConcurrentQueue<TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection.Enqueue(refAtStack);
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentQueue<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };
                        var collection = new ConcurrentQueue<TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection.Enqueue(new TestObjectRef() { Ref = obj });
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentQueue<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }

                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var collection = new ConcurrentStack<TestObject>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            var refAtStack = new TestObject() { String = teststring };
                            refAtStack.String += "1";
                            collection.Push(refAtStack);
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentStack<TestObject>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                    if (true)
                    {
                        GC.GetTotalMemory(true); long mem = GC.GetAllocatedBytesForCurrentThread();
                        var obj = new TestObject() { String = teststring };
                        var collection = new ConcurrentStack<TestObjectRef>();
                        for (int i = 0; i < objectCount; i++)
                        {
                            collection.Push(new TestObjectRef() { Ref = obj });
                        }
                        long totalmem = GC.GetAllocatedBytesForCurrentThread() - mem;
                        Console.Write(ret += $"ConcurrentStack<TestObjectRef>: ".PadRight(50, ' ') + $"{totalmem.ToString("N0").PadLeft(20, ' ')} B\n");//{Size(collection).ToString("N0").PadLeft(20,' ')} B 
                    }
                }
            }
            Console.Write(ret += "Press any key to exit");
            File.WriteAllText("out.txt", ret);
            Console.ReadLine();
        }
        static long Size(object o)
        {

            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                return s.Length;
            }

        }
    }
}
