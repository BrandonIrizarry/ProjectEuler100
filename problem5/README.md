# Problem 5

2520 is the smallest number that can be divided by each of the numbers 
from 1 to 10 without any remainder. What is the smallest positive number that is 
evenly divisible by all of the numbers from 1 to 20?

The high-level solution involves listing the primes from 2 to 19, and giving each
the largest exponent such that the resulting power is still in the sequence
2-20. You arrive at this by the algorithm formalized in [`problem5.fs`.](https://github.com/BrandonIrizarry/ProjectEuler100/blob/master/problem5/problem5.fs)
