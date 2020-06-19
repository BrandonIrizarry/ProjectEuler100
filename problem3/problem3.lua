package.path = package.path .. ';../?.lua'
local testing = require "testing"

--[[
	Problem 3

	The prime factors of 13195 are 5, 7, 13 and 29.

	What is the largest prime factor of the number 600851475143 ?
]]

local input = 600851475143
local sqrt, floor = math.sqrt, math.floor

local function divisor (n)
	for i = 2, floor(sqrt(n)) do
		if n % i == 0 then
			return i
		end
	end

	return n
end

local function largest (n)
	local quotient = n // divisor(n)

	if quotient == 1 then
		return n
	else
		return largest(quotient)
	end
end

assert(testing.is_correct(input, largest, 6857))
