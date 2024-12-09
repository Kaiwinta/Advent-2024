
input1=$(cat Day01/Input.txt)
input2=$(cat Day01/input2.txt)

firstList=(0)
secondList=(0)

for line in $input1
do
    echo "$line"
    firstList+=("$line")
done

for line in $Input2
do
    secondList+=("$line")
done

sortedFirstList=($(for i in "${firstList[@]}"; do echo "$i"; done | sort))
sortedSecondList=($(for i in "${secondList[@]}"; do echo "$i"; done | sort))

for element in $firstList
do
    echo -e "$element\n"
done