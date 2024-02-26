friends = ["muzi", "ryan", "frodo", "neo"]
gifts = ["muzi frodo", "muzi frodo", "ryan muzi", "ryan muzi", "ryan muzi", "frodo muzi", "frodo ryan", "neo muzi"]
def solution(friends, gifts):
    answer = 0
    record = {}
    # 계속 1차원 배열이겠지만 다른 배열에 배열이 들어가기때문에 3차원 배열처럼 사용함 
    # 딕셔너리형을 만들기위한 값이지만 딕셔너리가 아님 
    for f1 in friends:
        record[f1] = [0,{}]
        for f2 in friends:
            if f1 != f2:
                record[f1][1][f2] = 0 
    #print(record) 
    # record = {'muzi': [0, {'ryan': 0, 'frodo': 0, 'neo': 0}], 'ryan': [0, {'muzi': 0, 'frodo': 0, 'neo': 0}], 
    #           'frodo': [0, {'muzi': 0, 'ryan': 0, 'neo': 0}], 'neo': [0, {'muzi': 0, 'ryan': 0, 'frodo': 0}]}
    # 딕셔너리로 다 보낸값
    # friends는 하는게 없다
    # 친구 배열을 주기위한 정보를 주는것
    # gift 에서 다함 
    for gift in gifts:
        a,b = gift.split()
        record[a][0] += 1
        record[a][1][b] += 1
        record[b][0] -= 1
        record[b][1][a] -= 1
    print("a값",record[a][0])
    #print("b값",b)
    answer = [0] * len(friends)
    # 값 초기화 len 길이만큼 
    for a , value in record.items():
        # a값은"muzi", "ryan", "frodo", "neo" 순서대로 들어옵니다 
        index = friends.index(a)  # 순서대로 들고오는 역할 
        ex_p = value[0] # [-3, {'ryan': -3, 'frodo': 1, 'neo': -1}]
        for b, count in value[1].items(): # [2, {'muzi': 3, 'frodo': -1, 'neo': 0}]
     #       print(b)
            if count > 0 :
                answer[index] += 1
            elif count == 0:
                if ex_p > record[b][0]:
                    answer[index] +=1
    
    # 현 코드에서는 answer [1,2,1,2]
    return max(answer)
solution(friends, gifts)