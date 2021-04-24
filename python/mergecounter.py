def merge_counter(a, b):
    #If I can only go through the loop once, and I can't use things like count, merge, or sorting it... I can only think of literally going through everything
    # and saving it into a dictionary

    table = dict()
    for element in a:
        if (None == table.get(element)):
            table[element] = 1
        else:
            table[element] += 1
    
    for element in b:
        if (None == table.get(element)):
            table[element] = 1
        else:
            table[element] += 1

    return table
