def parse_input():
    value = ""
    with open ("Day06/input.txt") as src:
        value = src.readlines()
    return value

def find_guard(table :list[str]):
    for i in range(len(table)):
        x = table[i].find("^")
        if x != -1:
            return (i, x)
    raise ValueError("Table does not contain any guards")
        
def move(y, x, dir:list[int], backward :bool = False):
    if (backward):
        return (y - dir[0], x - dir[1])
    return (y + dir[0], x + dir[1])

def part1(table, get_list_traj :bool = False):
    list_case = []
    line_len = len(table[0])
    y, x = find_guard(table)
    dir = [-1, 0]

    while (True):
        case_index = y * line_len + x
        if (case_index not in list_case):
            list_case.append(case_index)

        y, x = move(y, x, dir)
        if y >= len(table) or y < 0:
            break
        if x >= line_len or x < 0:
            break
        while table[y][x] == "#":
            y, x = move(y, x, dir, backward=True)
            dir = rotate_dir(dir)
            y, x = move(y, x, dir)
    if (get_list_traj):
        return list_case
    return len(list_case)

def dir_to_string(dir):
    return f"0:{dir[0]}|1:{dir[1]}"

def rotate_dir(dir):
    save = dir[0]
    dir[0] = dir[1]
    dir[1] = save * -1
    return dir

def part2(table):
    line_len = len(table[0])
    nb_loop = 0
    guard_y, guard_x = find_guard(table)
    list_traj = part1(table, get_list_traj=True)

    # On parcours toutes les cases pour voir si la création à cet emplacement marche
    for obstacle_y in range(len(table)):
        for obstacle_x in range(len(table[obstacle_y])):
            case_index = obstacle_y * line_len + obstacle_x
            if (case_index not in list_traj):
                continue
            # On est sur un obstacle on ne peux pas en construire
            if (table[obstacle_y][obstacle_x] == "#"):
                continue
            # Reset de l'itération
            y, x = guard_y, guard_x
            dir = [-1, 0]
            list_case = set()
            # Boucle de déplacement
            while (True):
                case_index = y * line_len + x
                if ((case_index, dir_to_string(dir)) not in list_case):
                    list_case.add((case_index, dir_to_string(dir)))
                else:
                    nb_loop += 1
                    break
                y, x = move(y, x, dir)
                # Sortie de la carte
                if y >= len(table) or y < 0:
                    break
                if x >= line_len or x < 0:
                    break
                # On est sur l'obstacle ou sur celui que l'on veut construire, on les fait rotate
                while table[y][x] == "#" or (x == obstacle_x and y == obstacle_y):
                    y, x = move(y, x, dir, backward=True)
                    dir = rotate_dir(dir)
                    y, x = move(y, x, dir)
    return nb_loop

if __name__ == "__main__":
    data = parse_input()
    print(part1(data))
    print(part2(data))