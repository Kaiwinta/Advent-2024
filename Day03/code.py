import re

def parse_input():
    value = ""
    with open ("Day03/Input.txt") as src:
        value = src.read()
    return value

def part1(data :str):
    total = 0
    mul = re.findall("mul\([0-9]{1,3},[0-9]{1,3}\)", data)
    for match in mul:
        values = match.split("mul(")[1][:-1].split(",")
        total += int(values[0]) * int(values[1])
    return total

def part2(data):
    total = 0
    # Tous les multiplication avec un do et sans dont
    mul = re.findall("(do\(\)((?!don't\(\)).)*mul\([0-9]+,[0-9]+\))", data)
    # Tous les multiplication avec sans do ou don't au début
    start_mul = re.findall("^(((?!(don't\(\)|do\(\))).)*mul\([0-9]+,[0-9]+\))", data)
    for match in mul:
        total += part1(match[0])
    for match in start_mul:
        total += part1(match[0])
    print(total)

if __name__ == "__main__":
    data = parse_input()
    print(part1(data))
    part2(data)