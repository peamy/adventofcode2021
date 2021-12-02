import os, sys
sys.path.insert(1, os.path.join(sys.path[0], '..\..'))
from generic_functions import import_list_int

def solve(file):
    input = import_list_int(file)
    total = 0
    prev = -1
    for number in input:
        if(prev != -1 and number > prev):
            total+=1
        prev = number
    return total

def solve2(file):
    input = import_list_int(file)
    total = 0
    prev = -1
    count = len(input)
    for i in range(count-2):
        sum = (input[i] + input[i+1] + input[i+2]) / 3
        if(prev != -1):            
            if(sum > prev):
                total+=1
        prev = sum
        i+=1
    return total

print(solve("./input.txt"))
print(solve2("./input.txt"))