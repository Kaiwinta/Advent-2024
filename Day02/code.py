def part1():
    safe_count = 0
    with open("Day02/Input.txt") as src:
        reports = src.readlines()

    for report in reports:
        report = list(map(int, report.split()))
        if is_safe(report):
            safe_count += 1
    print(safe_count)

def is_safe(report):
    for i in range(len(report) - 1):
        diff = abs(report[i] - report[i + 1])
        if diff < 1 or diff > 3:
            return False
    increasing = all(report[i] < report[i + 1] for i in range(len(report) - 1))
    decreasing = all(report[i] > report[i + 1] for i in range(len(report) - 1))
    return increasing or decreasing

def can_be_safe_with_removal(report):
    for i in range(len(report)):
        # Delete the actual node to check if it's safe without
        modified_report = report[:i] + report[i + 1:]
        if is_safe(modified_report):
            return True
    return False

def part2():
    safe_count = 0
    with open("Day02/Input.txt") as src:
        reports = src.readlines()

    for report in reports:
        report = list(map(int, report.split()))
        if is_safe(report) or can_be_safe_with_removal(report):
            safe_count += 1
    print(safe_count)



if __name__ == "__main__":
    part1()
    part2()