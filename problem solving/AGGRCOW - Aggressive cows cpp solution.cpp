//Program to solve SPOJ - AGGRCOW problem
//Copyright for Hamza AlAjlouni

#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
	int n;
	cin >> n;

	while (n--)
	{
		int stalls, cows, locations[100001];
		cin >> stalls >> cows;
		for (int i = 0; i < stalls; i++)
			cin >> locations[i];
		sort(locations, locations + stalls);

		//binary algo
		int left_binary = locations[0], right_binary = locations[stalls - 1], mid = (right_binary + left_binary) / 2, gap = 0;
		while (left_binary <= right_binary)
		{
			//assigner start
			int count = 1, current_stall = 0;
			for (int i = 1; i < stalls && count < cows; i++)
			{
				mid = (right_binary + left_binary) / 2;
				if (locations[i] - locations[current_stall] >= mid)
				{
					current_stall = i;
					count++;
				}
			}
			//assigner end
			if (count == cows)
			{
				left_binary = mid + 1;
				gap = mid;
			}
			else 
				right_binary = mid - 1;
			
		}
		cout << gap << endl;
	}
	return 0;
}