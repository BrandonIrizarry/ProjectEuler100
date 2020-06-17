\ Problem 1
\ If we list all the natural numbers below 10 that are multiples of 3 or 5, we 
\ get 3, 5, 6 and 9. The sum of these multiples is 23. Find the sum of all the 
\ multiples of 3 or 5 below 1000.

: multiple ( n k --)
	mod 0= ;

: 3-or-5 ( n -- f)
	dup 3 multiple swap 5 multiple or ;

: filter ( n -- n | 0)
	dup 3-or-5 and ;

: maybe-add ( n x -- n + {0 | x})
	filter + ;

: main ( --)
	0 1000 3 do i maybe-add loop ;

main . \ 233168

\ Remarks
\ For me, the interesting word is FILTER. It muxes between the input and 0,
\ with the 3-or-5 flag as the selector.
