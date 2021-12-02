def import_list_string(filename):
    my_list = []

    with open(filename) as f:
        my_list = [line.rstrip() for line in f]

    return my_list


def import_list_int(filename):
    my_list = []
    my_list_int = []
    with open(filename) as f:
        my_list = [line.rstrip() for line in f]

    for line in my_list:
        my_list_int.append(int(line))


    return my_list_int