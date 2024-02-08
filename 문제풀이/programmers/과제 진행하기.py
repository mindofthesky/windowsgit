#plans = [name,start,playtime] 

#plans = [["korean", "11:40", "30"], ["english", "12:10", "20"], ["math", "12:30", "40"]]
plans = [["science", "12:40", "50"], ["music", "12:20", "40"], ["history", "14:00", "30"], ["computer", "12:30", "100"]]
# [['music', '12:20', '40'], ['computer', '12:30', '100'], ['science', '12:40', '50'], ['history', '14:00', '30']]
#result = ["korean", "english", "math"]
#result2 =  ["science", "history", "computer", "music"]
# result2 이유는 
# music 12:20 > 40분     |   걸려 > 30분에 인터럽트걸립니다 > 남은 시간 30분
# computer 12:30 > 100분 |   걸려 > 40분에 인터럽트 > 남은시간 90분 > 60분이 남습니다
# science 12:40 > 50분   |   걸려 > 50분 1시간 30분에 끝납니다 > append ! 남은 30분은 이전 작업에 먼저된것부터 합니다  
# history 14:00 > 30분   |   걸린다 > 뒤에게 없기때문에 끝냅니다 > 컴퓨터가 이전 작업이니까 다시 컴퓨터를 끝내고 > 뮤직을 끝냅니다
def solution(plans):
    answer = []
    for i in range(len(plans)):
        # [i][1] 을 초로 바뀌주기위해서 : 없애자 
        h, m = map(int,plans[i][1].split(':'))
        # map(int,plans[i][1].split(':')) 접근 방식을 생각을 못했다 두번 생각하자 
        #분
        # 정말 생각을 못했어 
        st = h*60+m
        # 시간 x 60 + m(분)
        # 내가 생각못했던게아니라 안되는줄 알았던 시간 계산부분  >> split 의심하기 
        plans[i][1] = st
        # 변수로 변환 
        plans[i][2] = int(plans[i][2])
        # h 시간의 값이 나와있고 m도 분으로 나눠져있음
    # 정렬먼저 
    # 스택문제추측은 맞음 
    interrupt = []
    # 빼주는 인터럽트 가 필요하다 생각했고 
    plans.sort(key=lambda x: x[1])
    print("plans 체크 " , plans)
    # 끝나면 추가해줘야함 append 
    for i in range(len(plans)):
        if i == len(plans)-1:
            print(plans[i])
            interrupt.append(plans[i])
            break
        sub1 , st1 , t1 = plans[i]
        sub2 , st2,  t2 = plans[i+1]
        if st1 + t1 <= st2:
            answer.append(sub1)
            temp = st2 - (st1+t1)
            print(temp)
            
            while temp != 0 and interrupt:
                temp_sub, temp_st, temp_t = interrupt.pop()
                if temp >= temp_t:
                    answer.append(temp_sub)
                    temp -= temp_t
                else:
                    interrupt.append([temp_sub, temp_st, temp_t - temp])
                    temp = 0 
        else:
            plans[i][2] = t1 - (st2 - st1)
            interrupt.append(plans[i])
    while interrupt:
        sub1 , st1 , t1 = interrupt.pop()
        answer.append(sub1)
    print(answer)
            
        
    return answer[::-1]
solution(plans)