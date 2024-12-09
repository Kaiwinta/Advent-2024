def parse_input():
    value = ""
    list_input = []
    with open ("Day07/Input.txt") as src:
        value = src.readlines()
    for line in value:
        splitted = line.split(":")
        list_input.append([int(splitted[0]), [int(val) for val in splitted[1].split(" ") if val != ""]])
    return list_input

def compute_res(operation :list, values :list):
    result = values[0]
    for i in range(1, len(values)):
        if (operation[i - 1] == 0):
            result += values[i]
        else:
            result *= values[i]
    return result

def increment_operation(operation :list):
    for i in range(len(operation) -1, -1, -1):
        if operation[i] == 1:
            operation[i] = 0
            continue
        if operation[i] == 0:
            operation[i] = 1
            break
    return operation

def part1(data : list):
    valid = 0
    for equation in data:
        desired_res = equation[0]
        operations = [0 for i in range(len(equation[1]) - 1)]
        nb_iteration = 0
        while (True and nb_iteration <= 2 ** (len(operations))):
            actual_res = compute_res(operations, equation[1])
            if (actual_res == desired_res):
                valid += 1
                break
            operations = increment_operation(operations)
            nb_iteration += 1
    return valid

def part2(data):
    return 0

if __name__ == "__main__":
    data = parse_input()
    print(part1(data))
    part2(data)