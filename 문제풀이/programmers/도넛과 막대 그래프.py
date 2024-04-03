# -*- coding: utf-8 -*-
"""
Created on Wed Apr  3 20:29:26 2024

@author: mindo
"""
# 도넛 모양 그래프, 막대 모양 그래프, 8자 모양 그래프들이 있습니다. 이 그래프들은 1개 이상의 정점과, 정점들을 연결하는 단방향 간선으로 이루어져 있습니다.
edges = [[2, 3], [4, 3], [1, 1], [2, 1]]
edges1 = [[4, 11], [1, 12], [8, 3], [12, 7], [4, 2], [7, 11], [4, 8], [9, 6], [10, 11], [6, 10], [3, 5], [11, 1], [5, 3], [11, 9], [3, 8]]
# 정점을 잡아야함 
# 정점을 2로잡은 거임 2가 2번나오니까
# 1,1 은 도넛 모형이라는 소리가됨 > 자기 자신을 돌아오게되면 분명히 
# 가장 많이 호출되는 숫자가 정점이됨 
# 가장 많이 호출될때 다시 자기 자신이되는건 없다고 생각해야함 
# edges = [[1, 1] [2, 1] [2, 3] [4, 3]]  정렬 
# result = 	[2, 1, 1, 0]
# edges1 = result = [4, 0, 1, 2]
def solution(edges):
    answer = []
    edges.sort(key=lambda x :(-x[0], x[1]))
    #print(edges1) 
    # 정점이게되면 호출갯수가 많다 > 정점은 edge[0] 가장 큰값이 정점이된다 
    # result 는 정해져있다
    # result[0] 정점 result[1] 도넛,result[2] 막대모양 그래프, result[3] 8모양 그래프
    # 도넛은 자기자신 
    #dict 해야할가?
    # 정점 구하는 방법은 알겠어 > dict 로 edges[0] 가장 많은 index가 정점이 됨 > 단 도넛형인경우 상관할필요가없음 ~ 도넛형이라도 
    # 카운터는 한번만함 
    count_edge = {}
    dic = dict()
    # dic, count_edge 는 같은 선언임 
    # 그러나 비전공자인경우 dict()로 선언할수도있음 
    max_val = 0
    # dic 선언과 {}값은 본질적으로 같기때문에 
    # 비교하면서 들어갔음 
    for edge in edges:
        if max_val < max(edge):
            max_val = max(edge)
        if edge[1] not in dic:
            count_edge[edge[1]] = []
            dic[edge[1]] = []
        if edge[0] not in dic:
            count_edge[edge[0]] = [edge[1]]
            dic[edge[0]] = [edge[1]]
        else:
            count_edge[edge[0]].append(edge[1])
            dic[edge[0]].append(edge[1])
    visited = [0 for i in range(max_val + 1)]
    edge_visited = [0 for i in range(max_val + 1)]
    for i in dic.values():
        for j in i:
            visited[j] = 1
            # 같은 값이있는애만뽑자 
            print(visited[j])
    for i in dic:
        if len(dic[i]) <= 1:
            visited[i] = 1
    for i, val in enumerate(visited):
        if i!=0 and val == 0:
            created_node = i
    print(visited)
    result = [0,0,0,0] 
    # 4개로 한정되어있음 
    visited = [0 for i in range(max_val+1)]
    edge_visited = [0 for i in range(max_val+1)]
    print(visited)
    
    def dfs(val):
    #모든 좌표를 가야하니 깊이 우선 검색
        start = val
        visited[start] = 1
        stack = [val]
        while stack:
            cur = stack.pop()
            
            if len(count_edge[cur]) == 0:
                result[2] += 1 
                return
            if len(count_edge[cur]) == 1 :
                if visited[dic[cur][0]] == 0:
                    stack.append(count_edge[cur][0])
                else:
                    result[1]  += 1 
                    return
            if len(count_edge[cur]) == 2:
                result[3] += 1
                return
    result[0] = created_node
    for i in count_edge[created_node]:
        dfs(i)
    return result
solution(edges)
solution(edges1)