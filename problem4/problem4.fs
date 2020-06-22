s" ../testing.fs" included
s" ../divisor.fs" included

\ Problem 4
\ 
\ A palindromic number reads the same both ways. The largest palindrome made from 
\ the product of two 2-digit numbers is 9009 = 91 × 99. Find the largest 
\ palindrome made from the product of two 3-digit numbers.

: 10** ( n -- n)	\ compute 10 raised to the nth power
	1 swap 0 ?do 10 * loop ;

: #digits ( n -- n)		\ compute number of digits of n
	0 swap begin
		10 / swap 1+ swap ?dup
	0= until ;

: shift ( n places --n)		\ left-shift n by places, but in base ten
	10** * ;

: reverse ( n --n)		\ computes the reverse of a number
	0 swap 2dup #digits 1- do
		10 /mod -rot i shift + swap
	-1 +loop drop ;

: palindromify ( n -- n) 	\ build a palindrome from n and its reverse
	dup reverse swap dup #digits shift + ;


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
