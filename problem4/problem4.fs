s" ../testing.fs" included

\ Problem 4
\ 
\ A palindromic number reads the same both ways. The largest palindrome made from 
\ the product of two 2-digit numbers is 9009 = 91 × 99. Find the largest 
\ palindrome made from the product of two 3-digit numbers.

variable palindrome

: ** ( n p -- n^p)
	1 swap 0 ?do
		over *
	loop nip ;

: power ( n -- 10^n)
	10 swap ** ;

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
		
