-- factorize a large (six-digit) number into two k-digit numbers
local function factorize (input, k)
	local limit = math.floor(math.sqrt(input))

	for i = limit, math.tointeger(10^(k-1)), -1 do
		local other = input // i

		if math.log(other,10) >= k then break end -- no more three-digit factor is possible

		if input % i == 0 then
			print(input, i, other)
			return true
		end
	end
end

-- Solve, but for an aribitrary k-number-of-digits for the factor-pair.
local function solve (k)
	local upper = math.tointeger(10^(2*k) - 1)
	local lower = math.tointeger(10^(2*(k-1)) + 1)

	-- For 'solve(3)' (which is what the original Project Euler formulation
	-- requires), you can decrement by 11 (not 1), since six-digit palindromes
	-- are divisible by 11. In the general case, though, it looks like you
	-- have to do away with this convenience.
	for i = upper, lower, -1 do
		local s = tostring(i)

		if s == s:reverse() and factorize(i, k) then break end
	end
end

--solve(3)
-- 906609	913		993

--solve(5)
-- ;9966006699	99681	99979
