-- factorize a large (six-digit) number into two three-digit numbers
local function factorize (input)
	local limit = math.floor(math.sqrt(input))

	for i = limit, 100, -1 do
		local other = input // i

		if math.log(other,10) >= 3 then break end -- no more three-digit factor is possible

		if input % i == 0 then
			print(input, i, other)
			return true
		end
	end
end

for i = 999999, 100001, -11 do -- six-digit palindromes are divisible by 11
	local s = tostring(i)

	if s == s:reverse() and factorize(i) then break end
end

-- 906609	913		993
