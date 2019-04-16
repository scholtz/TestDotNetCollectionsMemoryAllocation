# TestDotNetCollectionsMemoryAllocation

This application is intended to test basic memory allocation of selected collections in .NET

## Results .NET Core 2.2

```
Going to create N objects: 10
Testing with string: 
Hashtable<TestObject>:                                          18 000 B
Hashtable<TestObjectRef>:                                        1 568 B
Dictionary<int, TestObject>:                                     1 472 B
Dictionary<int, TestObjectRef>:                                  1 520 B
ConcurrentDictionary<int, TestObject>:                           1 568 B
ConcurrentDictionary<int, TestObjectRef>:                        1 616 B
HashSet<TestObject>:                                             1 816 B
HashSet<TestObjectRef>:                                          1 552 B
ConcurrentBag<TestObject>:                                       1 232 B
ConcurrentBag<TestObjectRef>:                                    1 256 B
Queue<TestObject>:                                                 848 B
Queue<TestObjectRef>:                                              896 B
ConcurrentQueue<TestObject>:                                     1 504 B
ConcurrentQueue<TestObjectRef>:                                  1 552 B
ConcurrentStack<TestObject>:                                       824 B
ConcurrentStack<TestObjectRef>:                                    872 B
Testing with string: 1234567
Hashtable<TestObject>:                                           2 000 B
Hashtable<TestObjectRef>:                                        1 568 B
Dictionary<int, TestObject>:                                     1 952 B
Dictionary<int, TestObjectRef>:                                  1 520 B
ConcurrentDictionary<int, TestObject>:                           2 048 B
ConcurrentDictionary<int, TestObjectRef>:                        1 616 B
HashSet<TestObject>:                                             1 720 B
HashSet<TestObjectRef>:                                          1 288 B
ConcurrentBag<TestObject>:                                       1 480 B
ConcurrentBag<TestObjectRef>:                                    1 048 B
Queue<TestObject>:                                               1 304 B
Queue<TestObjectRef>:                                              872 B
ConcurrentQueue<TestObject>:                                     1 984 B
ConcurrentQueue<TestObjectRef>:                                  1 552 B
ConcurrentStack<TestObject>:                                     1 304 B
ConcurrentStack<TestObjectRef>:                                    872 B
Testing with string: 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
Hashtable<TestObject>:                                           3 840 B
Hashtable<TestObjectRef>:                                        1 568 B
Dictionary<int, TestObject>:                                     3 792 B
Dictionary<int, TestObjectRef>:                                  1 520 B
ConcurrentDictionary<int, TestObject>:                           3 888 B
ConcurrentDictionary<int, TestObjectRef>:                        1 616 B
HashSet<TestObject>:                                             3 560 B
HashSet<TestObjectRef>:                                          1 288 B
ConcurrentBag<TestObject>:                                       3 320 B
ConcurrentBag<TestObjectRef>:                                    1 048 B
Queue<TestObject>:                                               3 144 B
Queue<TestObjectRef>:                                              872 B
ConcurrentQueue<TestObject>:                                     3 824 B
ConcurrentQueue<TestObjectRef>:                                  1 552 B
ConcurrentStack<TestObject>:                                     3 144 B
ConcurrentStack<TestObjectRef>:                                    872 B
Going to create N objects: 1000000
Testing with string: 
Hashtable<TestObject>:                                     136 678 224 B
Hashtable<TestObjectRef>:                                  136 672 816 B
Dictionary<int, TestObject>:                               123 445 200 B
Dictionary<int, TestObjectRef>:                            123 446 064 B
ConcurrentDictionary<int, TestObject>:                     152 020 408 B
ConcurrentDictionary<int, TestObjectRef>:                  152 027 624 B
HashSet<TestObject>:                                       101 888 560 B
HashSet<TestObjectRef>:                                    101 895 720 B
ConcurrentBag<TestObject>:                                  64 782 024 B
ConcurrentBag<TestObjectRef>:                               64 777 632 B
Queue<TestObject>:                                          64 783 856 B
Queue<TestObjectRef>:                                       64 779 864 B
ConcurrentQueue<TestObject>:                                64 783 488 B
ConcurrentQueue<TestObjectRef>:                             64 786 672 B
ConcurrentStack<TestObject>:                                80 005 304 B
ConcurrentStack<TestObjectRef>:                             80 006 584 B
Testing with string: 1234567
Hashtable<TestObject>:                                     184 672 704 B
Hashtable<TestObjectRef>:                                  136 668 560 B
Dictionary<int, TestObject>:                               171 448 160 B
Dictionary<int, TestObjectRef>:                            123 445 472 B
ConcurrentDictionary<int, TestObject>:                     200 020 440 B
ConcurrentDictionary<int, TestObjectRef>:                  152 026 208 B
HashSet<TestObject>:                                       149 893 216 B
HashSet<TestObjectRef>:                                    101 894 384 B
ConcurrentBag<TestObject>:                                 112 783 256 B
ConcurrentBag<TestObjectRef>:                               64 777 632 B
Queue<TestObject>:                                         112 777 736 B
Queue<TestObjectRef>:                                       64 780 680 B
ConcurrentQueue<TestObject>:                               112 784 136 B
ConcurrentQueue<TestObjectRef>:                             64 783 536 B
ConcurrentStack<TestObject>:                               128 005 072 B
ConcurrentStack<TestObjectRef>:                             80 004 632 B
Testing with string: 1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
Hashtable<TestObject>:                                     368 668 416 B
Hashtable<TestObjectRef>:                                  136 670 800 B
Dictionary<int, TestObject>:                               355 444 296 B
Dictionary<int, TestObjectRef>:                            123 443 648 B
ConcurrentDictionary<int, TestObject>:                     384 020 536 B
ConcurrentDictionary<int, TestObjectRef>:                  152 020 928 B
HashSet<TestObject>:                                       333 893 728 B
HashSet<TestObjectRef>:                                    101 897 096 B
ConcurrentBag<TestObject>:                                 296 777 936 B
ConcurrentBag<TestObjectRef>:                               64 777 632 B
Queue<TestObject>:                                         296 778 088 B
Queue<TestObjectRef>:                                       64 777 736 B
ConcurrentQueue<TestObject>:                               296 788 272 B
ConcurrentQueue<TestObjectRef>:                             64 786 008 B
ConcurrentStack<TestObject>:                               312 000 368 B
ConcurrentStack<TestObjectRef>:                             80 000 072 B
```
