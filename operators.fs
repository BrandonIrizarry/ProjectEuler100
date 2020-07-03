\ Here are some useful operators that sometimes feel like they're
\ missing when doing Project Euler problems.

\ Exponentiation
: ** ( n p -- n^p)
	1 swap 0 ?do
		over *
	loop nip ;

\ Compute greatest common divisor of two numbers a and b
: gcd ( a b -- gcd)
	begin tuck mod ?dup 0= until ;

\ Square a number
: square ( n -- n)
	dup * ;
