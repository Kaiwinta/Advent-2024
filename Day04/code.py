import re

def parse_input():
    value = ""
    with open ("Day04/Input.txt") as src:
        value = src.readlines()
    return value

def is_valid_or_desired_letter(letter :str, line_index :int, colls_index :int, data :list[str]) -> bool:
    if (line_index < 0 or colls_index < 0):
        return False
    if (line_index >= len(data)):
        return False
    if (colls_index >= len(data[line_index])):
        return False
    return data[line_index][colls_index] == letter

def get_desired_letter(line_index :int, colls_index :int, data :list[str]):
    if (line_index < 0 or colls_index < 0):
        return None
    if (line_index >= len(data)):
        return None
    if (colls_index >= len(data[line_index])):
        return None
    return data[line_index][colls_index]

def check_direction(x_base :int, y_base :int, x_margin :int, y_margin :int, data :list[str]) -> int:
    for letter in "MAS":
        x_base += x_margin
        y_base += y_margin
        if not is_valid_or_desired_letter(letter, y_base, x_base, data):
            return 0
    return 1

def check_surroundings(x_index :int, line_index :int, data: list[str]) -> int:
    total = 0
    total += check_direction(line_index, x_index, 1, 0, data)
    total += check_direction(line_index, x_index, 0, 1, data)
    total += check_direction(line_index, x_index, 1, 1, data)
    total += check_direction(line_index, x_index, -1, 0, data)
    total += check_direction(line_index, x_index, -1, -1, data)
    total += check_direction(line_index, x_index, 0, -1, data)
    total += check_direction(line_index, x_index, 1, -1, data)
    total += check_direction(line_index, x_index, -1, 1, data)
    return total

def part1(data) -> int:
    total = 0
    for i in range(len(data)):
        x_indexes = [m.start() for m in re.finditer('X', data[i])]
        for x_index in x_indexes:
            total += check_surroundings(x_index, i, data)
    return total

def find_x_pattern(x_index :int, line_index :int, data: list[str]) -> int:
    angles = [[None, None],[None, None]]
    angles[1][1] = get_desired_letter(line_index + 1, x_index + 1, data)
    angles[1][0] = get_desired_letter(line_index + 1, x_index - 1, data)
    angles[0][0] = get_desired_letter(line_index - 1, x_index - 1, data)
    angles[0][1] = get_desired_letter(line_index - 1, x_index + 1, data)
    if (angles[0].count(None) != 0 or angles[1].count(None) != 0):
        return 0
    if (angles[1][1] == angles[0][1] and angles[1][0] == angles[0][0]):
        values = angles[1][1] + angles[0][0]
        if (values.count("S") != 0 and values.count("M") != 0):
            return 1
    if (angles[1][1] == angles[1][0] and angles[0][0] == angles[0][1]):
        values = angles[1][1] + angles[0][0]
        if (values.count("S") != 0 and values.count("M") != 0):
            return 1
    return 0

def part2(data):
    total = 0
    for i in range(len(data)):
        a_indexes = [m.start() for m in re.finditer('A', data[i])]
        for a_index in a_indexes:
            total += find_x_pattern(a_index, i, data)
    return total


if __name__ == "__main__":
    data = parse_input()
    print(part1(data))
    print(part2(data))