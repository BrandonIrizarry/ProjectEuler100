s" ../testing.fs" included
s" ../operators.fs" included

\ Glossary
\
\ SQRT ( n -- n)
\ 	- Returns the floor of the square-root of its input.
\
\ /EVEN (a b -- quot f)
\ 	- Return quotient after dividing a by b, and signal whether
\ 	division was even.
\
\ FACTOR ( n -- x y)
\ 	- Factors n into two numbers x and y, such that x <= [sqrt(n)], and x
\ 	is the largest such number.
\
\ #REVERSE ( n -- n)
\ 	- Returns the palindrome of n (input and output are signed integers.)
\
\ PALINDROME ( n -- f)
\ 	- Return whether n is a palindrome.
\
\ 10-RAISE ( n -- 10^n)
\ 	- Raise n to the tenth power.
\
\ SOLVE ( k --)
\ 	- Use the above words to determine the largest palindrome that's a product
\ 	of two k-digit numbers.


: sqrt ( n -- floor{sqrt{n}})
	0 1 do
		dup i i * < if
			i 1- leave
	then loop nip ;

: /even ( n n -- quot f)
	/mod swap 0= ;
	
: factor ( N -- x y)
	dup sqrt swap >r 1+ 0 begin
		drop 1- \ set up arguments for the body of the loop
		r@ over /even
	until rdrop ;



: #reverse ( n--n)
	0 begin
		10 *
		swap 10 /mod
		-rot +
	over 0= until nip ;

: palindrome ( n --f)
	dup #reverse = ;

: 10-raise ( n -- 10^n)
	10 swap ** ;

: solve ( k --)		\ instead of 3-digit factors, find k-digit factors
	dup >r		\ send k to the return stack, we'll need it later as J
	dup 1- 2* 10-raise
	swap 2* 10-raise
	do
		i palindrome if
			i factor
			dup 10 j ** < if leave then 2drop
		then
	-1 +loop rdrop ;

false [if]
3 solve
	993 answer-is
	913 answer-is
	993 913 *
		906609 answer-is
	all-clear
[then]

5 solve
	99979 answer-is
	99681 answer-is
	99681 99979 *
		9966006699 answer-is
	all-clear
