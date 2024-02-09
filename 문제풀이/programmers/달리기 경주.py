# -*- coding: utf-8 -*-
"""
Created on Fri Feb  9 17:20:31 2024

@author: mindo
"""
# 무조건 제일 앞은 1등
# 콜링할때마다 등수가 증가 
# 최종값은 
# 연결리스트 문제?  >> 틀렸어
# 딕셔너리형 
players = ["mumu", "soe", "poe", "kai", "mine"]
callings = ["kai", "kai", "mine", "mine"]
#result = ["mumu", "kai", "mine", "soe", "poe"]
def solution(players, callings):
    answer = []
    # 왜 딕셔너리를 생각 못했지?
    # 무조건 for에 넣는 생각을 하는게 나쁜거같다 
    # 딕셔너리형으로 정의 
    player_dict = {players : rank for rank, players in enumerate(players)}
    # 플레이어 대한 랭크로 정의됨 
    rank_dict = {players : rank for rank, players in enumerate(players)}
    print(rank_dict.values(), rank_dict.keys())
    # 여기서는 시작부터 순서가 있기때문에 딕셔너리로 하면 끝이난다 
    for i in callings:
        index = rank_dict[i]
        # calling > 값 호출 4 등인값 들고오고
        # index가 rank_dict 복사
        print("시행전" ,index)
        rank_dict[i] -=1
        
        rank_dict[players[index -1]] +=1 
        players[index -1], players[index] = players[index],players[index-1]
        print("시행후", index)
        print("작업 1회 종료")
    
    answer = players
        # 체크용 코드로 확인
        #if players.index(callings[i]):
        #      players.index(callings[i])-1
              
              # 이렇게 했을때 문제점은 정렬이되지않는다
              # 그렇다면 연결로하면되나? 
              # 딕셔너리가연결리스트인데 
              # 물론 나도 인덱스로 따로 이동시켜주면 된다 생각했지만
              # 이러면 시간초과로 끝남 
    print(answer)      
    return answer

solution(players,callings)