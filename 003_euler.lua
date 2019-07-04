--[[
	The prime factors of 13195 are 5, 7, 13 and 29.
	
	What is the largest prime factor of the number 600851475143 ?
]]

local NUMBER = 600851475143

-- Get rid of "plumbing syntax".
function divides (a, b)
	return b % a == 0
end

-- Was originally the 'is_prime' predicate.
function extract (N)
	for j = 2, math.floor(math.sqrt(N)) do
		if divides(j, N) then
			return j -- smallest prime factor
		end
	end

	return N
end

-- Use 'extract' to cast out N's prime factors in ascending order.
-- Observing the output of Bash's 'factor' function was an inspiration for this.
function largest (N)
	local factor
	
	repeat
		factor = extract(N)
		N = N/factor
	until N == 1
	
	return factor
end

print(largest(NUMBER))

-- ALTERNATE SOLUTION USING COROUTINES
-- I realize coroutines don't contribute anything at this point, but 
-- I guess I had to realize that the hard way!
function fetch_prime ()

	local cache = {}
	
	for N = 2, math.huge do   -- walk through all natural numbers >= 2
		local factor = extract(N)
		if factor == N then coroutine.yield(N) end
	end
end

function primes (HI)
	local co = coroutine.create(fetch_prime)
	
	return function ()
		local _, p = coroutine.resume(co)
		return (p <= HI) and p or nil
	end
end

-- Example runs.
for p in primes(5) do print(p) end
for p in primes(100) do print(p) end

-- The main event.
local max = 0
for p in primes(math.floor(math.sqrt(NUMBER))) do 
	if divides(p, NUMBER) then max = p end
end

-- Done (but a bit slow.)
print(max)


