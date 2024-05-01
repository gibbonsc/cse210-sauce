import random

# initialize a list for counting rolls of dice
tallies = []
for i in range(13):
    tallies.append(0)
    # the minimum roll of two dice is 2, "snake eyes," so tallies[0] and tallies[1] will not be used

# roll dice many times and track the results
experimentSize = 10_000_000
print("Now rolling ten million pairs of dice.")
for roll in range(experimentSize):
    die1 = random.randint(1,6)
    die2 = random.randint(1,6)
    total = die1 + die2
    tallies[total]+=1

print(" ... finished rolling. Distribution graph:")
# display a graph of the tallies; should look somewhat like a triangular "bell curve"
scale = experimentSize//200
for i in range(2,13):
    print(f"{i: 3d}: ", end='')
    for graph_unit in range(tallies[i]//scale):
        print("#", end='')
    print(f" ({tallies[i]:,})")
print(f" (Scale: each # represents {scale:,} rolls.)")
