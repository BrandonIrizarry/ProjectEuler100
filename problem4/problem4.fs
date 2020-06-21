s" ../testing.fs" included

\ Problem 4
\ 
\ A palindromic number reads the same both ways. The largest palindrome made from 
\ the product of two 2-digit numbers is 9009 = 91 × 99. Find the largest 
\ palindrome made from the product of two 3-digit numbers.

\ TODO
\ I think we need to count digits! Makes reversing easier regardless
\ of how our new improvements changed things.

: 10** ( n -- n)	\ reverse logarithm-base-10
	1 swap 0 ?do 10 * loop ;

\ : reverse ( n --n)	\ reverses the last three digits of its input
\ 	0 swap 0 2 do
\ 		10 /mod -rot i 10** * + swap
\ 	-1 +loop drop ;

: reverse ( n #digits-1 --n)	\ reverses the last #digits digits of its input
	0 -rot 0 swap do
		10 /mod -rot i 10** * + swap
	-1 +loop drop ;

978 2 reverse 1 expectdepth .
10 1 reverse 1 expectdepth .

\ : build ( n --n)		\ build a candidate palindrome-product
\ 	dup reverse swap 1000 * + ;


false [if]
variable palindrome

: accum+ ( n --)
	palindrome +! ;

: accum@ ( --n)
	palindrome @ ;

: accum0 ( --)
	0 palindrome ! ;

: split ( n -- {reverse sequence of digits} #digits)
	0 1 do
		10 /mod ?dup if
			else i leave
	then loop ;

: build ( {reverse sequence of digits} #digits -- palindrome)
	accum0
	0 do i power * accum+ loop accum@ ;
 
: reverse ( n -- palindrome)
	split build ;
 
: palindromic ( n -- f)
	dup reverse = ;

: test ( n --)
	dup >r 1 swap do
		j i * palindromic if
			j . i . cr leave
	then -1 +loop rdrop ;

: main ( --)
	100 999 do
		i test
	-1 +loop ;
		
\ 100 991 test 0 expectdepth 
main .s
		
[then]
