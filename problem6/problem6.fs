s" ../testing.fs" included
s" ../operators.fs" included


: sn ( n --)
	dup 1+ 2 */ ;

: sn^2 ( n --)
	dup 1+ dup 2* 1- * 6 */ ;

100 sn square 100 sn^2  -

25164150  answer-is all-clear
