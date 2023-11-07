--------------Exercise 9.1--------------
(i)
See Selsort.il for commented lines
(ii)
See Selsort.jvmbytecode for commented lines


--------------Exercise 9.3--------------
i: Before any changes, running gives this result:
Exception: java.lang.OutOfMemoryError thrown from the UncaughtExceptionHandler in thread "Thread-0"
Exception in thread "main" java.lang.OutOfMemoryError: Java heap space

ii: The problem is that dummy.next points to the first inserted element of the queue, 
and since dummy is a field variable of the queue the reference remains in scope 
for the entire lifetime of the queue. This means that the elements before head are never garbage collected

See also QueueWithMistake.java line 104 for the change in code

Running the code after the change gives the following output:
SentinelLockQueue          1       8,47 199999994
SentinelLockQueue          2      28,34 199999994
SentinelLockQueue          3      89,01 199999994
SentinelLockQueue          4     109,15 199999994
SentinelLockQueue          5     135,09 199999994
SentinelLockQueue          6     161,85 199999994
SentinelLockQueue          7     182,22 199999994
SentinelLockQueue          8     214,65 199999994
SentinelLockQueue          9     243,62 199999994
SentinelLockQueue         10     277,46 199999994
SentinelLockQueue         11     329,22 199999994
SentinelLockQueue         12     339,80 199999994
SentinelLockQueue         13     388,16 199999994
SentinelLockQueue         14     395,07 199999994
SentinelLockQueue         15     442,37 199999994
SentinelLockQueue         16     505,71 199999994
SentinelLockQueue         17     529,75 199999994
SentinelLockQueue         18     591,96 199999994
SentinelLockQueue         19     647,83 199999994