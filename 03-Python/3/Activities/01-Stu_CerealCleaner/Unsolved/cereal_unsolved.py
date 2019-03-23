import os
import csv
#open csv file
cereal_csv = os.path.join("../Resources", "cereal.csv")
#configure csv read
with open(cereal_csv, newline="") as csvfile:
    csvreader = csv.reader(csvfile, delimiter=",")
    next(csvreader, None)

    for row in csvreader:
        if (float(row[7]) >= 5):
            print(row[0])
