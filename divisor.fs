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
