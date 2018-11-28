# Word Jumble
#
# The computer picks a random word and then "jumbles" it
# The player has to guess the original word

import random

# create a sequence of words to choose from
WORDS = ("python", "jumble", "easy", "difficult", "answer", "xylophone")

# pick one word randomly from the sequence
word = random.choice(WORDS)

# create a variable to use later to see if the guess is correct
correct = word

print "chosen word: ", correct, "len: ", len(correct)

# create a jumbled version of the word
jumble = ""

while word:
    position = random.randrange(len(word))
    jumble += word[position]
    word = word[(position+1):] + word[:position]
    print word

print(
"""
Welcome to Word Jumble!
Unscramble the letters to make a word.
(Press the enter key at the prompt to quit.)
"""
)

# start the game
print "The jumble is:", jumble

guess = input("\nYour guess: ")
while guess != correct and guess != "":
    print "Sorry, that's not it."
    guess = input("Your guess: ")

if guess == correct:
    print "You Have Won! Congrats!"

print "Thanks for playing."
input("\n\nPress the enter key to exit.")
