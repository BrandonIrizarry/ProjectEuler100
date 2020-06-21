\ Usage:
\
\ EXPECTDEPTH
\ Run a word. If you expect the stack to have depth n after running
\ that word, then run 'n expectdepth' right afterwards.  If the stack
\ doesn't have depth n, then EXPECTDEPTH will raise an error.
\
\ ANSWER-IS
\ Run a word. If you expect TOS to equal some value k, run 'k answer-is'
\ right afterwards. If n doesn't match k, an error is raised.

: expectdepth ( n --)
	depth 1- <>
		abort" stack depth doesn't check out" ;

: answer-is ( n ans --)
	over <>
		abort" answer doesn't match expected answer" ;


\ Some thoughts on why we use the word ANSWER-IS:
\ 1. We may solve in another programming language, get the right answer there,
\ and reimplement a solution in Forth.
\
\ 2. We've done some of the smaller-numbered problems before, and we just
\ want to check with the answers we earned access to previously (original
\ motivation.)
\
\ 3. We compute the correct answer once, but then update, improve, or otherwise
\ modify our original implementation, and so we'd like to check against the
\ correct answer within our own code, rather than always peek at the answer 
\ on the webpage, or somewhere else.
