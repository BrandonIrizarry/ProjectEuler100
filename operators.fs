\ Here are some useful operators that sometimes feel like they're
\ missing when doing Project Euler problems.

\ Exponentiation
: ** ( n p -- n^p)
	1 swap 0 ?do
		over *
	loop nip ;
