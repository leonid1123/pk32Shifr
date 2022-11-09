//ссылка на репозитарий https://github.com/leonid1123/pk32Shifr
using System.IO; //нужно для записи в файл
Console.WriteLine("Добро пожаловать в программу шифрования по методу ШИФР ЦЕЗАРЯ");
Console.WriteLine("Введите фразу для шифрования и нажмите ENTER");
string userInput = Console.ReadLine();
Console.WriteLine("Укажите сдвиг шифра в виде целого числа и нажмите ENTER");
int sdvig = int.Parse(Console.ReadLine());
string alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; //исходный алфавит
//формирование алфавита с указанным сдвигом
string newAlfavit = "";
for (int i = 0; i < alfavit.Length; i++) {
    int j = i + sdvig;
    if (j > 32) {//проверка, если дошли до конца исходного алфавита
        j = j - 33;
    }
    newAlfavit += alfavit[j];
}
Console.WriteLine("Исходный алфавит:{0}",alfavit);
Console.WriteLine("Алфавит со сдвигом {0}:{1}",sdvig,newAlfavit);
//Формирование зашифрованного слова. Взять буквы исходного слова поочереди
//найти их номер в исходном алфавите и взять букву с таким же номером в зашифрованном алфавите
string shifr = "";
for (int i = 0; i < userInput.Length; i++) {
    int letterNumber = alfavit.IndexOf(userInput[i]);
    Console.Write(newAlfavit[letterNumber]);
    shifr+=newAlfavit[letterNumber];
}
//Записать полученное слово и сдвиг в файл
//Write - перезаписывает файл, Append - дописывает
File.WriteAllText("res.txt",sdvig.ToString());
File.AppendAllText("res.txt",shifr);

