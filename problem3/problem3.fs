s" ../testing.fs" included 

\ Problem 3
\ The prime factors of 13195 are 5, 7, 13 and 29.
\ What is the largest prime factor of the number 600851475143 ?

600851475143 constant input

: sqrt ( n -- floor{sqrt{n}})
	>r		\ use in the loop body as 'j'
	
	0 1 do
		i dup * j > if
			i 1- leave
	then loop rdrop ;		\ don't forget to rdrop!


: divisor ( n -- smallest-divisor)
	dup sqrt 1+ 2 ?do
		dup i mod 0= if drop i leave then
	loop ;

: /divisor ( n -- smallest-divisor quotient)
	dup divisor tuck / ;

: largest ( n -- largest-prime-factor)
	/divisor dup 1 = if drop exit then
	nip recurse ;

input largest 1 expectdepth 6857 answer-is .

\ Remarks
\ Here, we successively compute smallest divisors of a running quotient,
\ until the number we reach is prime. This must be the largest,
\ because DIVISOR correctly computes the smallest prime divisor.
