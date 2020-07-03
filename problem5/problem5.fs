s" ../testing.fs" included
s" ../operators.fs" included \ for gcd

: solve ( --)
	1 21 2 do i 2dup gcd / * loop ;

solve 232792560 answer-is all-clear
