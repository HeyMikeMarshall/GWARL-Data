# @TODO: Write a function that returns the arithmetic average for a list of numbers


# Test your function with the following:
# print(average([1, 5, 9]))
# print(average(range(11)))

def average(mylist):
    if (len(mylist) == 0): return
    currentsum = 0
    for number in mylist:
        currentsum += number
    return currentsum / len(mylist)

print (average([2, 5, 3, 10]))