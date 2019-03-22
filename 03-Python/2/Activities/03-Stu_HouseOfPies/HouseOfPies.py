pieList = ["Pecan", "Apple Crisp", "Bean", "Banoffee", "Black Bun", "Blueberry", "Buko", "Burek", "Tamale", "Steak"]
pieCart = []
selections = "Y"
print(
"""
WELCOME TO THE HOUSE OF PIES! Please check out our selection of PIES

--------------------------------------------------------------------
(1) Pecan, (2) Apple Crisp, (3) Bean, (4) Banoffee,  (5) Black Bun, (6) Blueberry, (7) Buko, (8) Burek,  (9) Tamale, (10) Steak


""")
while selections == "Y":
    usrSelect = (int(input("Please enter the number for the pie of your desires: ")) - 1)
    pieCart.append(pieList[usrSelect])

    print("""

    --------------------------------------------------------------------
    
    """)
    print(f"Great! We'll have that {pieList[usrSelect]} pie right out for you!")
    selections = input("Would you like to order another pie? Y or N: ")
print(f"You have ordered {len(pieCart)} pies, Thank you!!")
