from collections import defaultdict

def parse_input():
    value = ""
    with open ("Day11/Input.txt") as src:
        value = src.readlines()
    value = value[0]
    value = [int(x) for x in value.split(" ")]
    return value

def blink(values):
    result = []
    for value in values:
        if value == 0:
            result.append(1)
            continue
        str_value = str(value)
        len_value = len(str_value)
        if len_value % 2 == 0:
            result.append(int(str_value[:int(len_value / 2)])) 
            result.append(int(str_value[int(len_value / 2):]))
            continue
        result.append(value * 2024)
    return result

def part1(values):
    for i in range(25):
        values = blink(values)

    return len(values)

def part2(values):
    stone_values = defaultdict(int)
    for value in values:
        stone_values[value] += 1
    for i in range(75):
        for index, amount in list(stone_values.items()):
            if amount == 0:
                continue
            if index == 0:
                stone_values[index] -= 1
                stone_values[i] += 1
                continue
            str_value = str(index)
            len_value = len(str_value)
            if len_value % 2 == 0:
                stone_values[int(str_value[:int(len_value / 2)])] += 1
                stone_values[int(str_value[int(len_value / 2):])] += 1
            else:
                stone_values[index * 2024] += 1
                stone_values[index] -= 1
    return sum(stone_values.values())
    
if __name__ == "__main__":
    data = parse_input()
    #print(part1(data))
    print(part2(data))