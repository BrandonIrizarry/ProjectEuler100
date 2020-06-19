

local M = {}

M.is_correct = function (input, routine, answer)
	local computed = routine(input)

	if answer then
		return computed == answer and answer or false
	else
		return computed
	end
end

return M
