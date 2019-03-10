# Parallel-and-Distributed-Programming
Labs for the parallel and distributed programming class using C#


Lab 1 problem statement :
  2. Bank accounts

At a bank, we have to keep track of the balance of some accounts. Also, each account has an associated log (the list of records of operations performed on that account). Each operation record shall have a unique serial number, that is incremented for each operation performed in the bank.
We have concurrently run transfer operations, to be executer on multiple threads. Each operation transfers a given amount of money from one account to someother account, and also appends the information about the transfer to the logs of both accounts.
From time to time, as well as at the end of the program, a consistency check shall be executed. It shall verify that the amount of money in each account corresponds with the operations records associated to that account, and also that all operations on each account appear also in the logs of the source or destination of the transfer.


Lab 2 problem statement :

Divide a simple task between threads. The task can easily be divided in sub-tasks requiring no cooperation at all. See the effects of false sharing, and the costs of creating threads and of switching between threads.
Requirement: write two problems: one for computing the sum of two matrices, the other for computing the product of two matrices.
Divide the task between a configured number of threads (going from 1 to the number of elements in the resulting matrix). See the effects on the execution time.


Lab 3 problem statement :

Take the same problems as for lab 2, but, instead of directly creating threads.


Lab 4 problem statement :

Parallelize the multiplication of 3 matrices. Use a configurable number of threads to do one matrix multiplication. Then, use another set of threads to do the second multiplication. The threads in the second set should start as soon as they start having data from the first multiplication result.
