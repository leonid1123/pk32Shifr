using System.IO;
Console.WriteLine("Добро пожаловать в программу шифрования по методу ШИФР ЦЕЗАРЯ");
Console.WriteLine("Введите фразу для шифрования и нажмите ENTER");
string userInput = Console.ReadLine();
Console.WriteLine("Укажите сдвиг шифра в виде целого числа и нажмите ENTER");
int sdvig = int.Parse(Console.ReadLine());
string alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
string newAlfavit = "";
for (int i = 0; i < alfavit.Length; i++) {
    int j = i + sdvig;
    if (j > 32) {
        j = j - 33;
    }
    newAlfavit += alfavit[j];
}
Console.WriteLine(alfavit);
Console.WriteLine(newAlfavit);
string shifr = "";
for (int i = 0; i < userInput.Length; i++) {
    int letterNumber = alfavit.IndexOf(userInput[i]);
    Console.Write(newAlfavit[letterNumber]);
    shifr+=newAlfavit[letterNumber];
}
File.WriteAllText("res.txt",shifr);
