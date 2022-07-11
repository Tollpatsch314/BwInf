all_students = []
highscore : int = 0

class Student:
    def __init__(self, nr, w1, w2, w3):
        self.nr = nr
        self.whishes = [w1 - 1 , w2 - 1, w3 - 1]



def read_file():
    try:
        with open(input("Geben Sie eine Datei an: "), "r") as file:
            i = -1
            for line in file:
                i += 1
                if i != 0:
                    wish = [int(char) for char in line.split() if char.isdigit()]
                    current_student = Student(i, wish[0], wish[1], wish[2])
                    all_students.append(current_student)


    except IOError:
        print("Konnte die Datei nicht lesen!")
        read_file()
    except:
        print("Fehler.")
        read_file()


def addperm(x,l):
    # Verschiebt das element 'x' in der Liste 'l'.
    # Am Anfang ist 'x' an 1. Stelle in der Liste, dann an 2. Stelle usw.
    # Solange um 1 nach hinten verschoben, bis 'x' das letzte Element in der Liste ist.
    return [ l[0:i] + [x] + l[i:]  for i in range(len(l)+1) ]

def perm(l):
    if len(l) == 0:
        return [[]]

    return [x for y in perm(l[1:]) for x in addperm(l[0],y) ]


def calc_highscore():
    # Definiert die Schwerpunkte der Punkteverteilung
    # Stellt sicher, dass die 'Erstwunscherfüllung' sehr stark gewichtet wird
    scores = [len(all_students) * len(all_students), len(all_students), 1]
    highscore = 0
    best_perm = None
    score = 0

    for p in perm(all_students):
        score = 0
        for i, person in enumerate(p):
            if person.whishes[0] == i:
                score += scores[0]
            
            elif person.whishes[1] == i:
                score += scores[1]
            
            elif person.whishes[2] == i:
                score += scores[2]
        if score > highscore:
            highscore = score
            best_perm = p
    return best_perm


def print_results(best_permutation):
    i = 0
    for s in best_permutation:
        i += 1
        print("Schüler: ", s.nr, " bekommt Geschenk ", i)


if __name__ == "__main__":
    read_file()
    best = calc_highscore()
    print_results(best)

    input("Drücken Sie eine beliebige Taste um das Programm zu beenden ")

