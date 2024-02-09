
# 다이,철,돌
# 다이아 0, 철 1 , 돌 2
# 사용할 수 있는 곡괭이중 아무거나 하나를 선택해 광물을 캡니다.
# 한 번 사용하기 시작한 곡괭이는 사용할 수 없을 때까지 사용합니다.
# 광물은 주어진 순서대로만 캘 수 있습니다.
# 광산에 있는 모든 광물을 캐거나, 더 사용할 곡괭이가 없을 때까지 광물을 캡니다.
# 0 ≤ dia, iron, stone ≤ 5
# dia는 다이아몬드 곡괭이의 수를 의미합니다.
#iron은 철 곡괭이의 수를 의미합니다.
# stone은 돌 곡괭이의 수를 의미합니다.
# 곡괭이는 최소 1개 이상 가지고 있습니다.
picks = [1, 3, 2]
minerals = ["diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond"]
picks1= [0, 1, 1]
minerals1 = ["diamond", "diamond", "diamond", "diamond", "diamond", "iron", "iron", "iron", "iron", "iron", "diamond"]
# answer = 12
# 단순 구현문제가 아닐까?
# 노가다성을 만드는 문제라고 생각하고 접근했으나
# 내가 맞닿드린 문제점은
# 어떻게 캐게할것인가 while?인가? 여기서 막혀서 답을 봐야했다 
def solution(picks, minerals):
    answer = 0
    sum =0
    # 이하 답을 통해작성한 코드 
       # 곡괭이의 수를 구한다.
    for i in picks:
         sum += i
       
       #곡괭이로 캘 수 있는 광물만큼 자른다.
    num = sum * 5
    if len(minerals)>sum:
        # 답을 결정하는 코드중 하나다 왜일까?
        print(minerals)   
        minerals = minerals[:num]
        # 15, 50 
        # 즉 캘수있는지 아닌지를 확인하게 해준다 슬라이싱
        print(minerals)   
       
       #광물들을 조사한다.
    # 람다를 생각하지 못했다 가상함수로 작성했으면됬는데    
    new_minerals =[[0,0,0] for i in range((len(minerals) //5 +1))]
    # 여기서 막힌게 나였다.. 
    print(new_minerals)
    # 0로해둔 수열 [[0, 0, 0], [0, 0, 0], [0, 0, 0]]
    # 대표적인 구현 노가다였는데 이건 이거 만났을때하면되지였지만 
    for i in range(len(minerals)):
        if minerals[i]=='diamond':
             new_minerals[i//5][0]+=1
        elif minerals[i]=='iron':
             new_minerals[i//5][1]+=1
        elif minerals[i]=='stone':
             new_minerals[i//5][2]+=1
             print(minerals[i//5][2])
       
       #광물의 순서를 다이아몬드, 철, 돌 순서대로 정렬해준다.
    new_minerals.sort(key=lambda x:(-x[0],-x[1],-x[2]))
    print(new_minerals) 
    # 재분류 
    # [[5, 0, 0], [0, 5, 0], [0, 0, 0]]
       #정렬된 광물들을 다이아,철,돌 곡괭이 순서대로 캔다.
    # while문으로 해야할줄 알았는데 이중포문으로 해결될지 생각을 못했다 
    for i in new_minerals:
        dia,iron,stone = i
        for j in range(len(picks)):
               if picks[j]>0 and j==0:
                   picks[j]-=1
                   answer += dia + iron + stone
                   break
               elif picks[j]>0 and j==1:
                   picks[j]-=1
                   answer += (5*dia) + iron + stone
                   break
               elif picks[j]>0 and j--2:
                   picks[j]-=1
                   answer += (25*dia) + (5*iron) + stone
                   break
    # answer 로 호출해보면 15다  >> 물론 다잘랐을 경우 15, 50 이 나오는 값은 틀리지 않은저미다 
    print(answer)
    return answer
solution(picks1, minerals1)
solution(picks, minerals)