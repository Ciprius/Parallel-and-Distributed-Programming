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


Lab 6 problem statement : 

Perform the multiplication of 2 polynomials. Use both the regular O(n2) algorithm and the Karatsuba algorithm, and each in both the sequencial form and a parallelized form. Compare the 4 variants.


Lab 7 problem statement :

1. Given a sequence of n numbers, compute the sums of the first k numbers, for each k between 1 and n. Parallelize the computations, to optimize for low latency on a large number of processors. Use at most 2*n additions, but no more than 2*log(n) additions on each computation path from inputs to an output. Example: if the input sequence is 1 5 2 4, then the output should be 1 6 8 12.

2. Add n big numbers. We want the result to be obtained digit by digit, starting with the least significant one, and as soon as possible. For this reason, you should use n-1 threads, each adding two numbers. Each thread should pass the result to the next thread. Arrange the threads in a binary tree. Each thread should pass the sum to the next thread through a queue, digit by digit.


Lab 8 problem statement :

Given a directed graph, find a Hamiltonean cycle, if one exists. Use multiple threads to parallelize the search.
