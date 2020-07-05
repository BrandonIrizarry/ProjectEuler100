s" ../testing.fs" included

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
\ SOLVE ( -- )
\ 	- Use the above words to determine the largest palindrome that's a product
\ 	of two three-digit numbers.


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

: solve ( --)
	10001 999999 do
		i palindrome if
			i factor
			dup 1000 < if leave then 2drop
		then
	-11 +loop ;

solve
	993 answer-is
	913 answer-is
	993 913 *
		906609 answer-is
	all-clear
