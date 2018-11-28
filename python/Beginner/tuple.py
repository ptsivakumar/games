tuple = ()
basket_tuple = (
    'One',
    'Two',
    'Three'
)

for item in basket_tuple:
    print(item)

# length

print "Number of Items:", len(basket_tuple)

# IN operator

if "One" in basket_tuple:
    print "One is in basket"

# index
end = len(basket_tuple)

for index in range(0,end):
    print basket_tuple[index]
