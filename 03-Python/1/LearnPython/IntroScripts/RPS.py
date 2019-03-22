# Incorporate the random library
import random

# Print Title
print("Let's Play Rock Paper Scissors!")

# Specify the three options
options = ["r", "p", "s"]

# Computer Selection
computer_choice = random.choice(options)

# User Selection
user_choice = input("Make your Choice: (r)ock, (p)aper, (s)cissors? ")

# Run Conditionals
if computer_choice == user_choice
    print("Draw!")

    elif computer_choice == "r"
        if user_choice == "s"
            print("Rock beats Scissors, you lose!")
        elif user_choice == "p"
            print("Paper beats Rock, you win!")

    elif computer_choice =
