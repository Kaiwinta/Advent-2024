
def part1():
    sum = 0 
    list1 = []
    list2 = []
    with open("Input.txt", "r") as src:
        list1 = src.read().splitlines()
    with open("input2.txt", "r") as src:
        list2 = src.read().splitlines()
    list1 = [int(x) for x in list1]
    list2 = [int(x) for x in list2]
    list1.sort()
    list2.sort()
    for i in range(len(list1)):
        sum += abs(list1[i] - list2[i])
    print (sum)


def part2():
    sum = 0 
    list1 = []
    list2 = []
    with open("Input.txt", "r") as src:
        list1 = src.read().splitlines()
    with open("input2.txt", "r") as src:
        list2 = src.read().splitlines()
    list1 = [int(x) for x in list1]
    list2 = [int(x) for x in list2]
    list1.sort()
    list2.sort()
    for i in range(len(list1)):
        sum += list1[i] * list2.count(list1[i])
    print (sum)


if __name__ == "__main__":
    part1()
    part2()