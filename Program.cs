//ссылка на репозитарий https://github.com/leonid1123/pk32Shifr
using System.IO; //нужно для записи в файл
//для работы с MySQL выполнить в терминале dotnet add package MySql.Data
//добавить в начало программы using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient;
Console.WriteLine("Добро пожаловать в программу шифрования по методу ШИФР ЦЕЗАРЯ");
var userInput = "";
do //проверка на ввод пустой строки
{
    Console.WriteLine("Введите слово на русском языке для шифрования и нажмите ENTER");
    userInput = Console.ReadLine();
} while (String.IsNullOrEmpty(userInput));
int sdvig;//для хранения величины сдвига
bool done=false;//для хранения успешности преобразования в целое число
do{//проверка на ввод целого числа в качестве сдвига
Console.WriteLine("Укажите сдвиг шифра в виде целого числа и нажмите ENTER");
//метод "int.PryParse" возвращает true если если удалось преобразовать в целое число и
// false если не удалось преобразовать. Если удалось преобразовать строку в целое число,
//то результат преобразования попадает в перемнуую sdvig
done = int.TryParse(Console.ReadLine(),out sdvig);
}while(!done);
string alfavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя"; //исходный алфавит
//формирование алфавита с указанным сдвигом
string newAlfavit = "";
for (int i = 0; i < alfavit.Length; i++)
{
    int j = i + sdvig;
    if (j > 32)
    {//проверка, если дошли до конца исходного алфавита
        j = j - 33;
    }
    newAlfavit += alfavit[j];
}
Console.WriteLine("Исходный алфавит: {0}", alfavit);
Console.WriteLine("Алфавит со сдвигом {0}: {1}", sdvig, newAlfavit);
//Формирование зашифрованного слова. Взять буквы исходного слова поочереди
//найти их номер в исходном алфавите и взять букву с таким же номером в зашифрованном алфавите
string shifr = "";
for (int i = 0; i < userInput.Length; i++)
{
    int letterNumber = alfavit.IndexOf(userInput[i]);
    shifr += newAlfavit[letterNumber];
}
Console.WriteLine("Зашифрованное слово: {0}",shifr);
//Записать полученное слово и сдвиг в файл
//Write - перезаписывает файл, Append - дописывает
File.WriteAllText("res.txt", sdvig.ToString());
File.AppendAllText("res.txt", shifr);

//Создать базу данных. Название: pk32
//Создать таблицу в базе данных pk32 с названием words. 
//Поля: id - тип int, добавить свойство A_I, word - тип text, sdvig - тип int
//Создать пользователя с именем pk32user и паролем 123456, дать ему все права
//создать строку для подключения
string cs = @"server=localhost;userid=pk32user;password=123456;database=pk32";
//создать объект для подключения и открыть соединение с БД
using var con = new MySqlConnection(cs);
con.Open();
//подготовить запрос с параметром
var sql = "INSERT INTO words(word, sdvig) VALUES(@word, @sdvig)";
using var cmd = new MySqlCommand(sql, con);
cmd.Parameters.AddWithValue("@word", shifr);
cmd.Parameters.AddWithValue("@sdvig", sdvig);
cmd.Prepare();
//выполнить запрос
cmd.ExecuteNonQuery();
Console.WriteLine("");
Console.WriteLine("Запись в БД выполнена.");
//todo
//написать "интерфейс" для того, чтобы пользователь мог выбрать что делать
//написать метод для шифрования и расшифрования из БД и из терминала
//написать метод для получения всех записей из БД
//