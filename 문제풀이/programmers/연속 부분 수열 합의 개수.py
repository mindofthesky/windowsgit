elements = [7,1,1,9,4]
def solution(elements):
    answer = 0
    a = sorted(elements)
    res = []
    print(sorted(elements))
    for i in range(len(elements)):
        for j in range(len(elements)):
            #print(sum(a[i:i+1]))
            res.append(sum(a[i:j+1]))
            print(len(set(res)))
    print(res)
    return answer