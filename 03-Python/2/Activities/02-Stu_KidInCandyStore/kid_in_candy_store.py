# The list of candies to print to the screen
candyList = ["Snickers", "Kit Kat", "Sour Patch Kids", "Juicy Fruit", "Swedish Fish",
             "Skittles", "Hershey Bar", "Starbursts", "M&Ms"]

# The amount of candy the user will be allowed to choose
allowance = 5
count = allowance
# The list used to store all of the candies selected inside of
candyCart = []

for candy in candyList:
    print("[" + str(candyList.index(candy)) + "]" + candy)

for x in range (allowance):
    print(f"You have {allowance} in allowance")
    print(f"Please select a candy.")
    usr_select = int(input("Enter the number of the candy you desire."))
    candyCart.append(candyList[usr_select])
    print(f"You have selected {candyCart}.")