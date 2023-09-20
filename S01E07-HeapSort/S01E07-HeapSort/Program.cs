using System;

int[] arr = { 17, 92, 5, 33, 68, 7, 56, 40, 24, 87,
    2, 13, 61, 98, 35, 75, 11, 26, 47, 99,
    31, 82, 49, 74, 6, 19, 51, 89, 70, 44,
    16, 94, 30, 83, 1, 38, 71, 57, 41, 55,
    3, 22, 66, 72, 36, 14, 8, 69, 95, 46,
    15, 73, 21, 59, 9, 29, 85, 64, 77, 78,
    50, 28, 67, 34, 76, 62, 45, 79, 91, 10,
    60, 84, 20, 23, 4, 27, 18, 54, 25, 81,
    63, 86, 58, 80, 42, 93, 12, 48, 53, 88,
    37, 96, 52, 97, 32, 65, 90, 43, 39, 100 };

int n = arr.Length;

Console.WriteLine("Array non ordinato:");
PrintArray(arr);

Sort(arr);

Console.WriteLine("Array ordinato:");
PrintArray(arr);


static void Sort(int[] arr)
{
    int n = arr.Length;

    // Costruisci un heap max (inizia dalla metà dell'array)
    for (int i = n / 2 - 1; i >= 0; i--)
    {
        Heapify(arr, n, i);
    }

    // Estrai uno per uno gli elementi dall'heap
    for (int i = n - 1; i > 0; i--)
    {
        // Scambia l'elemento radice (massimo) con l'ultimo elemento
        int temp = arr[0];
        arr[0] = arr[i];
        arr[i] = temp;

        // Chiamata a Heapify sul heap ridotto
        Heapify(arr, i, 0);
    }
}

static void Heapify(int[] arr, int n, int i)
{
    int largest = i; // Inizializza il più grande come radice
    int left = 2 * i + 1; // Indice del figlio sinistro
    int right = 2 * i + 2; // Indice del figlio destro

    // Se il figlio sinistro è più grande della radice
    if (left < n && arr[left] > arr[largest])
    {
        largest = left;
    }

    // Se il figlio destro è più grande del più grande finora
    if (right < n && arr[right] > arr[largest])
    {
        largest = right;
    }

    // Se il più grande non è la radice
    if (largest != i)
    {
        int swap = arr[i];
        arr[i] = arr[largest];
        arr[largest] = swap;

        // Richiama ricorsivamente Heapify sul sottoalbero colpito
        Heapify(arr, n, largest);
    }
}

static void PrintArray(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n; ++i)
    {
        Console.Write(arr[i] + " ");
    }

    Console.WriteLine();
}