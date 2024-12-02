def part1():
    safe_nb = 0
    reports = []
    with open("Day02/Input.txt") as src:
        reports = src.readlines()
    for report in reports:
        report = report.split(' ')
        report = [int(value) for value in report]
        sorted = (all(report[i] < report[i+1] for i in range(len(report) - 1))
                 or all(report[i] > report[i+1] for i in range(len(report) - 1)))
        if sorted == False:
            continue
        level_differed = (all(report[i] - report[i+1] <= 3 and report[i] - report[i+1] > 0 for i in range(len(report) - 1))
                        or all(report[i + 1] - report[i] <= 3 and report[i + 1] - report[i] > 0 for i in range(len(report) - 1)))
        if level_differed == False:
            continue
        safe_nb += 1
    print(safe_nb)

def part2():
    safe_nb = 0
    reports = []
    comparator = 0
    with open("Day02/Input.txt") as src:
        reports = src.readlines()
    for report in reports:
        report = report.split(' ')
        report = [int(value) for value in report]
        superior = 0
        inferior = 0
        equals = 0
        for i in range(len(report)):
            superior += report[i] > report[i + 1]
            inferior += report[i] < report[i + 1]
            equals   += report[i] == report[i + 1]
        # Too much invalids datas
        if (superior > 1 and (inferior > 1 or equals > 1) or (inferior > 1 and equals > 1)):
            continue


if __name__ == "__main__":
    part1()
    part2()