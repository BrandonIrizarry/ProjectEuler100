--[[
	If we list all the natural numbers below 10 that are multiples of 3 or 5,
we get 3, 5, 6 and 9. The sum of these multiples is 23.

	Find the sum of all the multiples of 3 or 5 below 1000.
]]

function gauss_sum (n)
	return n * (n + 1) // 2
end

--[[
	3(1000 = 333 R 1, so the last multiple to consider is 999,
	and calculate 999/3 to build the appropriate series: 333.
	
	5(1000 = 200 R 0, so the last multiple to consider is 995,
	and calculate 995/5 ... 199.
	
	15(1000 = 66 R 10, so the last multiple to consider is 990,
	and calculate 990/15 ... 66.
	
	So we'd calculate
	
	  (1 + ... + 333) * 3
	+ (1 + ... + 199) * 5
	- (1 + ... + 66)  * 15
	-----------------------
		= FINAL ANSWER
]]

-- The answer is 223168.
print(gauss_sum(333) * 3 + gauss_sum(199) * 5 - gauss_sum(66) * 15)