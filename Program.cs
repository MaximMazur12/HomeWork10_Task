
int[] numbers = new int[100000];  // масив з 100000 елементів від 1 до 100000

for (int i = 0; i < 100000; i++)
{
    numbers[i] = i + 1;
}

SquaresDelegate squaresDelegate = new SquaresDelegate(FindSquares); // Створення делегата для пошуку чисел з цілим коренем
List<int> results = new List<int>(); // List для результату

Task[] task = new Task[4]; // Створення 4 тасків
int range = 100000 / 4; // ділим на 4 таски порівну

for (int i = 0; i < 4; i++)
{
    int start = i * range;
    int finish = (i + 1) * range;

    task[i] = Task.Run(() => squaresDelegate(start, finish, numbers, results)); // Запускаєм Таск через лямбду з делегатом
}

static void FindSquares(int start, int finish, int[] numbers, List<int> result)
{
    for (int i = start; i < finish; i++)
    {
        int num = numbers[i];
        double squareRoot = Math.Sqrt(num);
        if (squareRoot == (int)squareRoot)
        {
            result.Add(num);
        }
    }
}
Task.WaitAll(task); // Очікування завершення всіх задач

Console.WriteLine("Result:");
foreach (int result in results)
{
    Console.WriteLine(result);
}

delegate void SquaresDelegate(int a, int b, int[] c, List<int> results); // створюєм сам делегат

