s" ../testing.fs" included

\ figure out if input is a palindrome
\ TODO: find a simpler definition of PALINDROME
: #digits ( n -- n)		\ compute number of digits of n
	0 swap begin
		10 / swap 1+ swap ?dup
	0= until ;

: 10** ( n --n)
	1 swap 0 ?do 10 * loop ;

: shift ( n places --n)		\ left-shift n by places, but in base ten
	10** * ;

: reverse ( n --n)		\ computes the reverse of a number
	0 swap 2dup #digits 1- do
		10 /mod -rot i shift + swap
	-1 +loop drop ;

: palindrome ( n --f)
	dup reverse = ;




: sqrt ( n -- floor{sqrt{n}})
	0 1 do
		dup i i * < if
			i 1- leave
	then loop nip ;

: /even ( n n -- quot f) \ flag signals even-division
	/mod swap 0= ;
	
\ factors N into two numbers, but the smaller factor is the largest number
\ x such that x <= floor(sqrt(N))
: factor ( N -- x y)
	dup sqrt swap >r 1+ 0 begin
		drop 1- \ set up arguments for the body of the loop
		r@ over /even
	until rdrop ;

: solve ( --)
	10001 999999 do
		i palindrome if
			i factor
			dup 1000 < if leave then 2drop
		then
	-1 +loop ;

solve
	993 answer-is
	913 answer-is
	993 913 *
		906609 answer-is
	all-clear
	
