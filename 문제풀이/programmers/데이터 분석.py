data = [[1, 20300104, 100, 80], [2, 20300804, 847, 37], [3, 20300401, 10, 8]]
ext = "date"
val_ext = 20300501	
sort_by ="remain"
# data 데이터의 정보는
# code	date  maximum	remain
# ext가 정렬 기준 > 전체 기준 
# sort_by data[0]가 갯수에 대한 정렬 기준
# ext 기준에서 작은숫자부터 
def solution(data, ext, val_ext, sort_by):
    # [[]] 인경우 빈칸이 하나있기때문에 []로 변경
    answer = []
    # dict 예상한대로 선언
    dict = {"code":0, "date":1, "maximun":2, "remain":3}
    # code	date  maximum	remain
    # dict 해야될것같은데 ?
    for i in data:
    # 답참조한결과
    # dict를 크기로 하는 방법을 몰랐다
    # 좀 알았다 싶어도 이거때문에 고생하고 이거때문에 참고를하게되니까 
    # 그래도 배운게 있다고본다 
        res = i[dict[ext]]
        if res <= val_ext:
            answer.append(i)
            
    answer.sort(key = lambda x : x[dict[sort_by]])        
    return answer

solution(data, ext, val_ext, sort_by)
